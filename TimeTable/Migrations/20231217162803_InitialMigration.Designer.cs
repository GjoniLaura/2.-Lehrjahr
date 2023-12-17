﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeTable.DatabaseConnection;

#nullable disable

namespace TimeTable.Migrations
{
    [DbContext(typeof(TimeTableContext))]
    [Migration("20231217162803_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TimeTable.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("TimeTable.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("_designation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("_premises")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
