﻿// <auto-generated />
using System;
using Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(SalonDBContext))]
    partial class SalonDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data_Access_Layer.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("FeedbackText")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FeedbackTitle")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsVerify")
                        .HasColumnType("bit");

                    b.HasKey("FeedbackId");

                    b.HasIndex("ClientId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"), 1L, 1);

                    b.Property<double>("MaterialAmount")
                        .HasColumnType("float");

                    b.Property<int>("MaterialManufacturerManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaterialId");

                    b.HasIndex("MaterialManufacturerManufacturerId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.MaterialManufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerId"), 1L, 1);

                    b.Property<DateTime>("BestBeforeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MadeIn")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ManufacturerId");

                    b.ToTable("MaterialManufacturers");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.MediaFile", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileDescription")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("MediaFiles");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfService")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<double>("OrderPrice")
                        .HasColumnType("float");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Procedure", b =>
                {
                    b.Property<int>("ProcedureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcedureId"), 1L, 1);

                    b.Property<string>("ProcedureName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<float>("ProcedurePrice")
                        .HasColumnType("real");

                    b.Property<int>("ProcedureType")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeAmount")
                        .HasColumnType("datetime2");

                    b.HasKey("ProcedureId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.ProFile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ProfileTitle")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ProfileId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduleDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ScheduleTitle")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ScheduleId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Specialization", b =>
                {
                    b.Property<int>("SpecializationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecializationId"), 1L, 1);

                    b.Property<int>("ProcedureType")
                        .HasColumnType("int");

                    b.HasKey("SpecializationId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("EmployeeOrder", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("EmployeeOrder");
                });

            modelBuilder.Entity("EmployeeSpecialization", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationsSpecializationId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeId", "SpecializationsSpecializationId");

                    b.HasIndex("SpecializationsSpecializationId");

                    b.ToTable("EmployeeSpecialization");
                });

            modelBuilder.Entity("MaterialProcedure", b =>
                {
                    b.Property<int>("MaterialsMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("ProceduresProcedureId")
                        .HasColumnType("int");

                    b.HasKey("MaterialsMaterialId", "ProceduresProcedureId");

                    b.HasIndex("ProceduresProcedureId");

                    b.ToTable("MaterialProcedure");
                });

            modelBuilder.Entity("OrderProcedure", b =>
                {
                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProceduresProcedureId")
                        .HasColumnType("int");

                    b.HasKey("OrdersOrderId", "ProceduresProcedureId");

                    b.HasIndex("ProceduresProcedureId");

                    b.ToTable("OrderProcedure");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Feedback", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Client", "Client")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Material", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.MaterialManufacturer", "MaterialManufacturer")
                        .WithMany("Materials")
                        .HasForeignKey("MaterialManufacturerManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialManufacturer");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.MediaFile", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.ProFile", "Profile")
                        .WithMany("MediaFiles")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Order", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Entities.Schedule", null)
                        .WithMany("Orders")
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.ProFile", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Employee", "Employee")
                        .WithOne("ProFile")
                        .HasForeignKey("Data_Access_Layer.Entities.ProFile", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Schedule", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Employee", "Employee")
                        .WithOne("Schedule")
                        .HasForeignKey("Data_Access_Layer.Entities.Schedule", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeOrder", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeSpecialization", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Entities.Specialization", null)
                        .WithMany()
                        .HasForeignKey("SpecializationsSpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaterialProcedure", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialsMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Entities.Procedure", null)
                        .WithMany()
                        .HasForeignKey("ProceduresProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderProcedure", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Entities.Procedure", null)
                        .WithMany()
                        .HasForeignKey("ProceduresProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Client", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Employee", b =>
                {
                    b.Navigation("ProFile")
                        .IsRequired();

                    b.Navigation("Schedule")
                        .IsRequired();
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.MaterialManufacturer", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.ProFile", b =>
                {
                    b.Navigation("MediaFiles");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Schedule", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
