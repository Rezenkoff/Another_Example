using Microsoft.EntityFrameworkCore;
using Monitor.Persistence.Dashboard.Models;


namespace Monitor.Persistence.Dashboard
{
    public class DashboardContext : DbContext
    {
        //Migration console commands: 
        // dotnet ef migrations add {Migration Name} -s ..\Monitor.WebUI\ --context DashboardContext
        // dotnet ef database update -s ..\Monitor.WebUI\ --context DashboardContext

        public DashboardContext(DbContextOptions<DashboardContext> options) 
            : base(options)
        {
        }

        public DbSet<EFMontlySalesInfoModel> MontlySalesInfo { get; set; }
        public DbSet<EFGoogleAnaliticCache> GoogleAnalitCache { get; set; }
        public DbSet<EFLostCallRateModel> LostCallRate { get; set; }
        public DbSet<EFReturnedOrder> ReturnedOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {

        }
    }
}
