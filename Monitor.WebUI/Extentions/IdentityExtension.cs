using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Monitor.DAL.Models;

namespace Monitor.WebUI.Extentions
{
    public static class IdentityExtension
    {
        public static IdentityBuilder AddAutodocIdentity(this IServiceCollection services)
        {
            return services.AddIdentity<AutodocUser, AutodocRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 5;
            });
        }
    }
}
