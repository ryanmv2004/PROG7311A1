﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROG7311.Data;

#nullable disable

namespace PROG7311.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250513113445_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("PROG7311.Models.Employee", b =>
                {
                    b.Property<int>("employeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("employeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PROG7311.Models.Farmer", b =>
                {
                    b.Property<int>("farmerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("farmerID");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("PROG7311.Models.Product", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("dateAdded")
                        .HasColumnType("TEXT");

                    b.Property<int>("farmerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("productCategory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("productID");

                    b.HasIndex("farmerID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PROG7311.Models.Product", b =>
                {
                    b.HasOne("PROG7311.Models.Farmer", "farmer")
                        .WithMany("products")
                        .HasForeignKey("farmerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("farmer");
                });

            modelBuilder.Entity("PROG7311.Models.Farmer", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
