﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Model;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220917152323_meters addd")]
    partial class metersaddd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Model.CityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rmz")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.BuildingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuildName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacilityIdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacilityIdId");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.ElectricMeterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ElectricMeter");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.FloorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuildingId")
                        .HasColumnType("int");

                    b.Property<string>("FloorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floor");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.WaterMeterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WaterMeter");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.ZoneModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingMode")
                        .HasColumnType("int");

                    b.Property<int>("CityModel")
                        .HasColumnType("int");

                    b.Property<int>("FacilityMode")
                        .HasColumnType("int");

                    b.Property<int>("FacilityModel")
                        .HasColumnType("int");

                    b.Property<string>("ZoneName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingMode");

                    b.HasIndex("CityModel");

                    b.HasIndex("FacilityMode");

                    b.HasIndex("FacilityModel");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("WebApplication1.Model.FacilityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityIdId")
                        .HasColumnType("int");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityIdId");

                    b.ToTable("Facility");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.BuildingModel", b =>
                {
                    b.HasOne("WebApplication1.Model.FacilityModel", "FacilityId")
                        .WithMany("Building")
                        .HasForeignKey("FacilityIdId");

                    b.Navigation("FacilityId");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.FloorModel", b =>
                {
                    b.HasOne("WebApplication1.Model.DataModel.BuildingModel", "Building")
                        .WithMany("Floor")
                        .HasForeignKey("BuildingId");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.ZoneModel", b =>
                {
                    b.HasOne("WebApplication1.Model.DataModel.BuildingModel", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingMode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Model.CityModel", "cityId")
                        .WithMany()
                        .HasForeignKey("CityModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Model.FacilityModel", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityMode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Model.DataModel.FloorModel", "FloorId")
                        .WithMany("Zone")
                        .HasForeignKey("FacilityModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("cityId");

                    b.Navigation("Facility");

                    b.Navigation("FloorId");
                });

            modelBuilder.Entity("WebApplication1.Model.FacilityModel", b =>
                {
                    b.HasOne("WebApplication1.Model.CityModel", "CityId")
                        .WithMany("Facilites")
                        .HasForeignKey("CityIdId");

                    b.Navigation("CityId");
                });

            modelBuilder.Entity("WebApplication1.Model.CityModel", b =>
                {
                    b.Navigation("Facilites");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.BuildingModel", b =>
                {
                    b.Navigation("Floor");
                });

            modelBuilder.Entity("WebApplication1.Model.DataModel.FloorModel", b =>
                {
                    b.Navigation("Zone");
                });

            modelBuilder.Entity("WebApplication1.Model.FacilityModel", b =>
                {
                    b.Navigation("Building");
                });
#pragma warning restore 612, 618
        }
    }
}
