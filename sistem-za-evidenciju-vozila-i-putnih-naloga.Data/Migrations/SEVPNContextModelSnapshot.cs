﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Migrations
{
    [DbContext(typeof(SEVPNContext))]
    partial class SEVPNContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("ChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EnginPowerKS")
                        .HasColumnType("float");

                    b.Property<double>("EnginPowerKW")
                        .HasColumnType("float");

                    b.Property<string>("EngineNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("CarModelId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.CarBrand", b =>
                {
                    b.Property<int>("CarBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CarBrandId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("CarBrand");

                    b.HasData(
                        new
                        {
                            CarBrandId = 1,
                            Name = "Audi"
                        },
                        new
                        {
                            CarBrandId = 2,
                            Name = "Peuget"
                        },
                        new
                        {
                            CarBrandId = 3,
                            Name = "Mercedes"
                        },
                        new
                        {
                            CarBrandId = 4,
                            Name = "BMW"
                        },
                        new
                        {
                            CarBrandId = 5,
                            Name = "Citroen"
                        },
                        new
                        {
                            CarBrandId = 6,
                            Name = "Renault"
                        },
                        new
                        {
                            CarBrandId = 7,
                            Name = "VW"
                        });
                });

            modelBuilder.Entity("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.CarModel", b =>
                {
                    b.Property<int>("CarModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CarModelId");

                    b.HasIndex("CarBrandId");

                    b.HasIndex("Name", "CarBrandId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("CarModel");

                    b.HasData(
                        new
                        {
                            CarModelId = 1,
                            CarBrandId = 1,
                            Name = "TT"
                        },
                        new
                        {
                            CarModelId = 2,
                            CarBrandId = 2,
                            Name = "306"
                        },
                        new
                        {
                            CarModelId = 3,
                            CarBrandId = 3,
                            Name = "S"
                        },
                        new
                        {
                            CarModelId = 4,
                            CarBrandId = 4,
                            Name = "X6"
                        },
                        new
                        {
                            CarModelId = 5,
                            CarBrandId = 2,
                            Name = "r2"
                        },
                        new
                        {
                            CarModelId = 6,
                            CarBrandId = 3,
                            Name = "er2"
                        },
                        new
                        {
                            CarModelId = 7,
                            CarBrandId = 7,
                            Name = "Golf 2"
                        });
                });

            modelBuilder.Entity("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriverId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.TravelWarrant", b =>
                {
                    b.Property<int>("TravelWarrantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("EndLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfPassengers")
                        .HasColumnType("int");

                    b.Property<string>("StartLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("TravelWarrantId");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.ToTable("TravelWarrant");
                });

            modelBuilder.Entity("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.Car", b =>
                {
                    b.HasOne("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.CarModel", b =>
                {
                    b.HasOne("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.CarBrand", "CarBrand")
                        .WithMany()
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.TravelWarrant", b =>
                {
                    b.HasOne("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}