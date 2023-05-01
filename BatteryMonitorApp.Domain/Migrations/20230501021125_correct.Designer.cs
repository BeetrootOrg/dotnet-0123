﻿// <auto-generated />
using System;
using BatteryMonitorApp.Domain.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BatteryMonitorApp.Domain.Migrations
{
    [DbContext(typeof(BatteryMonitorContext))]
    [Migration("20230501021125_correct")]
    partial class correct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BatteryMonitorApp.Domain.Models.DataBase.BatteryData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<float>("Current")
                        .HasColumnType("real");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("Voltage")
                        .HasColumnType("real");

                    b.Property<float>("VoltageCharger")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Batteries_Data");
                });
#pragma warning restore 612, 618
        }
    }
}
