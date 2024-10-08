﻿// <auto-generated />
using System;
using FardTest.Dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FardTest.Migrations
{
    [DbContext(typeof(CongestionTaxDbContext))]
    [Migration("20240920165655_InitialCreatee")]
    partial class InitialCreatee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FardTest.Models.TaxRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaxRules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 8,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 6, 29, 59, 0),
                            StartTime = new TimeSpan(0, 6, 0, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 2,
                            Amount = 13,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 6, 59, 59, 0),
                            StartTime = new TimeSpan(0, 6, 30, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 3,
                            Amount = 18,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 7, 59, 59, 0),
                            StartTime = new TimeSpan(0, 7, 0, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 4,
                            Amount = 13,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 8, 29, 59, 0),
                            StartTime = new TimeSpan(0, 8, 0, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 5,
                            Amount = 8,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 14, 59, 59, 0),
                            StartTime = new TimeSpan(0, 8, 30, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 6,
                            Amount = 13,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 15, 29, 59, 0),
                            StartTime = new TimeSpan(0, 15, 0, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 7,
                            Amount = 18,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 16, 59, 59, 0),
                            StartTime = new TimeSpan(0, 15, 30, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 8,
                            Amount = 13,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 17, 59, 59, 0),
                            StartTime = new TimeSpan(0, 17, 0, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 9,
                            Amount = 8,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 18, 29, 59, 0),
                            StartTime = new TimeSpan(0, 18, 0, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 10,
                            Amount = 0,
                            City = "Gothenburg",
                            EndTime = new TimeSpan(0, 5, 59, 59, 0),
                            StartTime = new TimeSpan(0, 18, 30, 0, 0),
                            Year = 2013
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
