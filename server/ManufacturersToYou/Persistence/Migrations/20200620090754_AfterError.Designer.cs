﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200620090754_AfterError")]
    partial class AfterError
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("ManufacturerId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Manufacturer", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany("Manufacturers")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.HasOne("Domain.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Domain.Manufacturer", null)
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("Domain.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });
#pragma warning restore 612, 618
        }
    }
}
