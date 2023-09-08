﻿// <auto-generated />
using System;
using EmployeeApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeApi.Models.Employee", b =>
                {
                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<string>("employeeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("employeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("employeeSalary")
                        .HasColumnType("int");

                    b.Property<int>("supervisorId")
                        .HasColumnType("int");

                    b.HasKey("employeeId", "employeeCode");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeApi.Models.EmployeeAttendence", b =>
                {
                    b.Property<DateTime>("attendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<bool>("isAbsent")
                        .HasColumnType("bit");

                    b.Property<bool>("isOffday")
                        .HasColumnType("bit");

                    b.Property<bool>("isPresent")
                        .HasColumnType("bit");

                    b.ToTable("EmployeeAttendences");
                });

            modelBuilder.Entity("EmployeeApi.Models.MonthlyAttendanceReport", b =>
                {
                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonthName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PayableSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalAbsent")
                        .HasColumnType("int");

                    b.Property<int>("TotalOffday")
                        .HasColumnType("int");

                    b.Property<int>("TotalPresent")
                        .HasColumnType("int");

                    b.ToTable("MonthlyAttendanceReports");
                });
#pragma warning restore 612, 618
        }
    }
}