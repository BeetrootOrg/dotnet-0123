﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Name;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceManagement.Domain.Migrations
{
    [DbContext(typeof(FinanceManagementContext))]
    [Migration("20230514082026_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinanceManagement.Domain.Database.Accounting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<long>("AssigneeId")
                        .HasColumnType("bigint")
                        .HasColumnName("assignee_id");

                    b.Property<TimeSpan>("Created_at")
                        .HasColumnType("interval")
                        .HasColumnName("created_at");

                    b.Property<long[]>("Iterations")
                        .IsRequired()
                        .HasColumnType("bigint[]")
                        .HasColumnName("iterations");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<float>("Value")
                        .HasMaxLength(255)
                        .HasColumnType("real")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.ToTable("Accountings");
                });

            modelBuilder.Entity("FinanceManagement.Domain.Database.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("FinanceManagement.Domain.Database.Accounting", b =>
                {
                    b.HasOne("FinanceManagement.Domain.Database.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");
                });
#pragma warning restore 612, 618
        }
    }
}
