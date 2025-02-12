using Supporter_Api.Database;

namespace Supporter_Api.Common.Repository.Providers
{
    public record BaseUserRepositoryProvider(MyDbContext DbContext, IHttpContextAccessor HttpContextAccessor)
}
