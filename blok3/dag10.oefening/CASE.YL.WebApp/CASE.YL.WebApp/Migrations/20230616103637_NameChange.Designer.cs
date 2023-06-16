﻿// <auto-generated />
using System;
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
    [Migration("20230616103637_NameChange")]
    partial class NameChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CASE.YL.WebApp.Models.Cursist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Custisten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Achternaam = "Jan",
                            Voornaam = "Gert"
                        },
                        new
                        {
                            Id = 2,
                            Achternaam = "Bogard",
                            Voornaam = "Pieter"
                        },
                        new
                        {
                            Id = 3,
                            Achternaam = "Zuid",
                            Voornaam = "Kelly"
                        });
                });

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

                    b.ToTable("Cursussen");

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

            modelBuilder.Entity("CASE.YL.WebApp.Models.Cursusinstantie", b =>
                {
                    b.Property<int>("CususId")
                        .HasColumnType("int");

                    b.Property<int>("CursistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("datetime2");

                    b.HasKey("CususId", "CursistId");

                    b.HasIndex("CursistId");

                    b.ToTable("Cursusinstanties");

                    b.HasData(
                        new
                        {
                            CususId = 1,
                            CursistId = 1,
                            Startdatum = new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CususId = 2,
                            CursistId = 1,
                            Startdatum = new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CususId = 3,
                            CursistId = 2,
                            Startdatum = new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CASE.YL.WebApp.Models.Cursusinstantie", b =>
                {
                    b.HasOne("CASE.YL.WebApp.Models.Cursist", "Cursist")
                        .WithMany("Cursusinstanties")
                        .HasForeignKey("CursistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CASE.YL.WebApp.Models.Cursus", "Cursus")
                        .WithMany("Cursusinstanties")
                        .HasForeignKey("CususId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cursist");

                    b.Navigation("Cursus");
                });

            modelBuilder.Entity("CASE.YL.WebApp.Models.Cursist", b =>
                {
                    b.Navigation("Cursusinstanties");
                });

            modelBuilder.Entity("CASE.YL.WebApp.Models.Cursus", b =>
                {
                    b.Navigation("Cursusinstanties");
                });
#pragma warning restore 612, 618
        }
    }
}
