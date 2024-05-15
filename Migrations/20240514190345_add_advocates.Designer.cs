﻿// <auto-generated />
using EFCorePlayground.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCorePlayground.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20240514190345_add_advocates")]
    partial class add_advocates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("EFCorePlayground.Models.Advocate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Products")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Technologies")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Advocates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Maarten Balliauw",
                            Products = "[\"IntelliJ IDEA\",\"Rider\",\"ReSharper\"]",
                            Technologies = "[\".NET\",\"Java\"]"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Matthias Koch",
                            Products = "[\"ReSharper\",\"Rider\",\"Qodana\",\"Team City\"]",
                            Technologies = "[\".NET\",\"CI\"]"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rachel Appel",
                            Products = "[\"ReSharper\",\"Rider\"]",
                            Technologies = "[\".NET\",\"JavaScript\"]"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Matt Ellis",
                            Products = "[\"Rider\",\"Gateway\"]",
                            Technologies = "[\".NET\",\"Unreal\",\"Unity\",\"Java\"]"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Khalid Abuhakmeh",
                            Products = "[\"Rider\",\"RustRover\"]",
                            Technologies = "[\".NET\",\"Rust\"]"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
