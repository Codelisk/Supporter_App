using System.Linq.Expressions;
using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using Supporter_Api.Database;
using Supporter_Api.Helpers;

namespace Supporter_Api.Common.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct
    {
        private readonly MyDbContext _context;

        protected BaseRepository(MyDbContext myDbContext)
        {
            this._context = myDbContext;
        }

        [Add]
        public virtual async Task<TEntity> Add(TEntity t)
        {
            EntityEntry<TEntity> result;
            t.CreatedAt = DateTimeHelpers.Now();
            DoBeforeAddOrSave(t);
            result = await _context.Set<TEntity>().AddAsync(t);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        [AddRange]
        public virtual async Task<List<TKey>> AddRange(List<TEntity> list)
        {
            foreach (var item in list)
            {
                item.CreatedAt = DateTimeHelpers.Now();
                DoBeforeAddOrSave(item);
            }
            await _context.Set<TEntity>().AddRangeAsync(list);

            await _context.SaveChangesAsync();
            return list.Select(x => x.GetId()).ToList();
        }

        [Save]
        public virtual async Task<TEntity> Save(TEntity t)
        {
            var foundEntity = await _context.Set<TEntity>().FindAsync(t.GetId());
            if (foundEntity == null)
            {
                return await Add(t);
            }

            DoBeforeAddOrSave(foundEntity);
            var result = _context.Entry(foundEntity);
            result.CurrentValues.SetValues(t);

            await _context.SaveChangesAsync();
            return result.Entity;
        }

        [Get]
        public virtual async Task<TEntity?> Get(TKey id)
        {
            return await EntityByIdAsync(id);
        }

        [GetLast]
        public virtual async Task<TEntity?> GetLastOrDefault()
        {
            try
            {
                var result = await _context
                    .Set<TEntity>()
                    .AsNoTracking()
                    .OrderBy(x => x.CreatedAt)
                    .ToListAsync();
                if (result is null)
                {
                    return null;
                }
                return FilterBeforeReturn(result).LastOrDefault();
            }
            catch (System.InvalidOperationException ex)
            {
                throw new InvalidOperationException(
                    $"Most likely {typeof(TEntity).FullName} does not inherit {typeof(ICreatedAt).FullName}.",
                    ex
                );
            }
        }

        [GetAll]
        public virtual async Task<List<TEntity>> GetAll()
        {
            var result = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            if (result is null)
            {
                return new List<TEntity>();
            }

            return FilterBeforeReturn(result!);
        }

        public async Task<List<TEntity>> GetAll(List<TKey> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new List<TEntity>();
            }
            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            var primaryKey = entityType.FindPrimaryKey();

            if (primaryKey.Properties.Count != 1)
                throw new InvalidOperationException(
                    "Entität hat keinen einzelnen Primärschlüssel."
                );

            var primaryKeyProperty = primaryKey.Properties.First();

            return await _context
                .Set<TEntity>()
                .AsNoTracking()
                .Where(e => ids.Contains(EF.Property<TKey>(e, primaryKeyProperty.Name)))
                .ToListAsync();
        }

        [Delete]
        public virtual async Task<bool> Delete(TKey id)
        {
            var entity = await EntityByIdAsync(id);
            if (entity is null)
            {
                return false;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<List<TEntity>> EntityByPropertyAsync<TValue>(
            string propertyName,
            TValue propertyValue
        )
        {
            // Hol die Entitätensammlung (DbSet<TEntity>)
            var entityType = typeof(TEntity);
            var property = entityType.GetProperty(propertyName);

            if (property == null)
            {
                throw new ArgumentException(
                    $"Property '{propertyName}' does not exist on type '{entityType.Name}'."
                );
            }

            // Dynamische Bedingung: propertyName == propertyValue
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var propertyExpression = Expression.Property(parameter, property.Name);

            Expression valueExpression;
            if (property.PropertyType == typeof(Guid?) && propertyValue is Guid guidValue)
            {
                // Konvertiere TValue in Nullable<Guid>, falls es sich um Guid handelt
                valueExpression = Expression.Constant((Guid?)guidValue, typeof(Guid?));
            }
            else if (property.PropertyType == typeof(Guid) && propertyValue is Guid guidNonNullable)
            {
                // Falls Property nicht nullable ist, passe den Wert direkt an
                valueExpression = Expression.Constant(guidNonNullable, typeof(Guid));
            }
            else
            {
                // Standardwert für andere Typen
                valueExpression = Expression.Constant(propertyValue);
            }

            // Vergleiche Nullable-Typen korrekt
            Expression equalExpression;
            if (property.PropertyType == typeof(Guid?))
            {
                // Nullable<Guid>: Vergleiche die Werte nach Typanpassung
                var hasValueExpression = Expression.Property(propertyExpression, "HasValue");
                var valueAccessExpression = Expression.Property(propertyExpression, "Value");
                var compareExpression = Expression.Equal(
                    Expression.Convert(valueAccessExpression, typeof(Guid?)),
                    Expression.Convert(valueExpression, typeof(Guid?))
                );

                // Nullable-Typen sind nur gleich, wenn HasValue true ist und die Werte gleich sind
                equalExpression = Expression.AndAlso(hasValueExpression, compareExpression);
            }
            else
            {
                // Normaler Vergleich für Nicht-Nullable-Typen
                equalExpression = Expression.Equal(propertyExpression, valueExpression);
            }

            // Hauptbedingung als Lambda-Ausdruck
            var mainCondition = Expression.Lambda<Func<TEntity, bool>>(equalExpression, parameter);

            // Prüfe, ob TEntity IVersion implementiert, und füge eine zusätzliche Bedingung hinzu

            var result = await _context
                .Set<TEntity>()
                .Where(mainCondition)
                .AsNoTracking()
                .ToListAsync();

            // Wenn TEntity kein IVersion ist, nutze nur die Hauptbedingung
            return FilterBeforeReturn(result);
        }

        public virtual async Task<int> DeleteAllAsync(bool areYouSure = false)
        {
            if (!areYouSure)
            {
                throw new Exception("You have to be sure.");
            }
            var all = await GetAll();
            var result = all.Count;
            _context.RemoveRange(all);
            await _context.SaveChangesAsync();
            return result;
        }

        public virtual async Task<List<TEntity>> GetRangeAsync(List<TKey> ids)
        {
            // Fetch all entities and filter by ids using HashSet.Contains
            var result = await GetAll(ids);
            return result;
        }

        public virtual async Task<int> DeleteAllByRangeAsync(List<TKey> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return 0; // Keine IDs zum Löschen
            }

            var range = await GetRangeAsync(ids);
            _context.Set<TEntity>().RemoveRange(range);
            await _context.SaveChangesAsync();
            return range.Count;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().CountAsync();
        }

        public abstract List<TEntity> FilterBeforeReturn(List<TEntity> entities);

        public abstract void DoBeforeAddOrSave(TEntity t);

        ValueTask<TEntity?> EntityByIdAsync(TKey id)
        {
            if (id is Guid idGuid)
            {
                return _context.Set<TEntity>().FindAsync(idGuid);
            }

            throw new KeyNotFoundException();
        }
    }
}
