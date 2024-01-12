﻿// <auto-generated />
using System;
using EFEClore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFEClore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240112120402_mtmRel")]
    partial class mtmRel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFEClore.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EFEClore.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EFEClore.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("chemistry")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("physics")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("programming")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("studentId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("EFEClore.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("departmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFEClore.Models.StudentBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("getDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("bookId");

                    b.HasIndex("studentId");

                    b.ToTable("StudentBooks");
                });

            modelBuilder.Entity("EFEClore.Models.Grade", b =>
                {
                    b.HasOne("EFEClore.Models.Student", "student")
                        .WithOne("grade")
                        .HasForeignKey("EFEClore.Models.Grade", "studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });

            modelBuilder.Entity("EFEClore.Models.Student", b =>
                {
                    b.HasOne("EFEClore.Models.Department", "department")
                        .WithMany("Students")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("EFEClore.Models.StudentBook", b =>
                {
                    b.HasOne("EFEClore.Models.Book", "book")
                        .WithMany("Students")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFEClore.Models.Student", "student")
                        .WithMany("Books")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("student");
                });

            modelBuilder.Entity("EFEClore.Models.Book", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EFEClore.Models.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EFEClore.Models.Student", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("grade")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
