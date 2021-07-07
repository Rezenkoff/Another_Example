using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitor.Persistence.Dashboard.Models;


namespace Monitor.Persistence.Dashboard.Configurations
{
    public class MonthlySalesInfoConfiguration : IEntityTypeConfiguration<EFMontlySalesInfoModel>
    {
        public void Configure(EntityTypeBuilder<EFMontlySalesInfoModel> builder)
        {
            builder.Property(e => e.Year)
                .IsRequired();

            builder.Property(e => e.Month)
                .IsRequired();

        }
    }
}
