﻿// <auto-generated />
using CASE.YL.WebApp.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CASE.YL.WebApp.Migrations
{
    [DbContext(typeof(CursusContext))]
    [Migration("20230616091116_Cursisten")]
    partial class Cursisten
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CASE.YL.WebApp.Models.Cursus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duur")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursusen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PROC#",
                            Duur = 4,
                            Titel = "Programming C#"
                        },
                        new
                        {
                            Id = 2,
                            Code = "PROC++",
                            Duur = 2,
                            Titel = "Programming C++"
                        },
                        new
                        {
                            Id = 3,
                            Code = "PROCPython",
                            Duur = 5,
                            Titel = "Programming Python"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
