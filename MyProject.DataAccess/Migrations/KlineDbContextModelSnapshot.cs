using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyProject.DataAccess;
using MyProject.DataAccess.Entities;

#nullable disable

namespace MyProject.DataAccess.Migrations;

[DbContext(typeof(KlineDbContext))]
partial class KlineDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

        modelBuilder.Entity<KlineEntity>(b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER");

            b.Property<decimal>("Close")
                .HasColumnType("TEXT");

            b.Property<decimal>("High")
                .HasColumnType("TEXT");

            b.Property<decimal>("Low")
                .HasColumnType("TEXT");

            b.Property<decimal>("Open")
                .HasColumnType("TEXT");

            b.Property<long>("StartTime")
                .HasColumnType("INTEGER");

            b.Property<string>("Symbol")
                .IsRequired()
                .HasColumnType("TEXT");

            b.Property<string>("Interval")
                .IsRequired()
                .HasColumnType("TEXT");

            b.Property<decimal>("Turnover")
                .HasColumnType("TEXT");

            b.Property<decimal>("Volume")
                .HasColumnType("TEXT");

            b.HasKey("Id");

            b.HasIndex("Symbol", "Interval", "StartTime")
                .IsUnique();

            b.ToTable("Klines");
        });
    }
}
