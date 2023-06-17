﻿// <auto-generated />
using System;
using Dag8.oefening1.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dag8.oefening1.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20230609130354_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dag8.oefening1.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UitersteDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Doe de afwas",
                            IsDone = false,
                            Title = "afwas",
                            UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Doe de afwas2",
                            IsDone = false,
                            Title = "afwas",
                            UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Description = "Doe de afwas3",
                            IsDone = false,
                            Title = "afwas",
                            UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}