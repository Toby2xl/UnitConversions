﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Units.Infrastructure.Data;

#nullable disable

namespace Units.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ConversionDbContext))]
    partial class ConversionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Units.Core.Conversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Dimension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Factor")
                        .HasColumnType("numeric");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Dimension");

                    b.HasIndex("Id");

                    b.ToTable("Conversions", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
