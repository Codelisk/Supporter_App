using System.Collections.Generic;
using Codelisk.GeneratorAttributes.WebAttributes.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Supporter_Api.Database
{
    [BaseContext]
    public partial class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        partial void GeneratedModelCreating(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            GeneratedModelCreating(modelBuilder);
        }
    }
}
