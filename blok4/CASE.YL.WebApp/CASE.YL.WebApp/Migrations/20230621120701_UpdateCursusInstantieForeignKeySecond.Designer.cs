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
    [Migration("20230621120701_UpdateCursusInstantieForeignKeySecond")]
    partial class UpdateCursusInstantieForeignKeySecond
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Custisten");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Cursist");

                    b.UseTphMappingStrategy();
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CursistId")
                        .HasColumnType("int");

                    b.Property<int>("CursusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CursistId");

                    b.HasIndex("CursusId");

                    b.ToTable("Cursusinstanties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CursistId = 1,
                            CursusId = 1,
                            Startdatum = new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CursistId = 1,
                            CursusId = 2,
                            Startdatum = new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CursistId = 4,
                            CursusId = 2,
                            Startdatum = new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CursistId = 5,
                            CursusId = 2,
                            Startdatum = new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CursistId = 6,
                            CursusId = 2,
                            Startdatum = new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CursistId = 2,
                            CursusId = 3,
                            Startdatum = new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CASE.YL.WebApp.Models.Bedrijfsmedewerker", b =>
                {
                    b.HasBaseType("CASE.YL.WebApp.Models.Cursist");

                    b.Property<string>("Afdeling")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bedrijfsnaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Offertenummer")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Bedrijfsmedewerker");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Achternaam = "Stevens",
                            Voornaam = "Gerard",
                            Afdeling = "Inkoop",
                            Bedrijfsnaam = "Amazon",
                            Offertenummer = 12345678
                        },
                        new
                        {
                            Id = 5,
                            Achternaam = "Kentelier",
                            Voornaam = "Josoef",
                            Afdeling = "Goudsmith",
                            Bedrijfsnaam = "Juwelier Vreriks",
                            Offertenummer = 48375198
                        },
                        new
                        {
                            Id = 6,
                            Achternaam = "Truida",
                            Voornaam = "Samuel",
                            Afdeling = "Inkoop",
                            Bedrijfsnaam = "Apple",
                            Offertenummer = 47293343
                        });
                });

            modelBuilder.Entity("CASE.YL.WebApp.Models.Particulier", b =>
                {
                    b.HasBaseType("CASE.YL.WebApp.Models.Cursist");

                    b.Property<int?>("Huisnummer")
                        .HasColumnType("int");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rekeningnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straatnaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Woonplaats")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Particulier");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Achternaam = "Jan",
                            Voornaam = "Gert",
                            Huisnummer = 10,
                            Postcode = "7573BZ",
                            Rekeningnummer = "NL04ABNA4938384777",
                            Straatnaam = "Spoorstraat",
                            Woonplaats = "Bloemendaal"
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

            modelBuilder.Entity("CASE.YL.WebApp.Models.Cursusinstantie", b =>
                {
                    b.HasOne("CASE.YL.WebApp.Models.Cursist", "Cursist")
                        .WithMany("Cursusinstanties")
                        .HasForeignKey("CursistId");

                    b.HasOne("CASE.YL.WebApp.Models.Cursus", "Cursus")
                        .WithMany("Cursusinstanties")
                        .HasForeignKey("CursusId")
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
