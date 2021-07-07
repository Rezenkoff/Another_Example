﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monitor.Persistence.Dashboard;

namespace Monitor.Persistence.Migrations
{
    [DbContext(typeof(DashboardContext))]
    [Migration("20191111152343_AddPK")]
    partial class AddPK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monitor.Persistence.Dashboard.Models.EFMontlySalesInfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ActualSalesSumm");

                    b.Property<short>("Month");

                    b.Property<decimal>("PlannedSalesSumm");

                    b.Property<short>("Year");

                    b.HasKey("Id");

                    b.ToTable("MontlySalesInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
