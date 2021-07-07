using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Monitor.DAL.Models;

namespace Monitor.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<AutodocUser, AutodocRole, int>
    {
        private static readonly bool[] _migrated = { false };

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
