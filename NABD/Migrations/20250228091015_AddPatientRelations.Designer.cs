﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NABD.Data;

#nullable disable

namespace NABD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250228091015_AddPatientRelations")]
    partial class AddPatientRelations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2e39ce08-64e1-40c4-b25a-ab98e1345be0",
                            ConcurrencyStamp = "2e39ce08-64e1-40c4-b25a-ab98e1345be0",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "4e5bd3e5-6cf5-4b08-9c41-ccc761fb6de1",
                            ConcurrencyStamp = "4e5bd3e5-6cf5-4b08-9c41-ccc761fb6de1",
                            Name = "MedicalStaff",
                            NormalizedName = "MEDICALSTAFF"
                        },
                        new
                        {
                            Id = "b8da6f82-e554-4f87-8b8b-f61e9891bd33",
                            ConcurrencyStamp = "b8da6f82-e554-4f87-8b8b-f61e9891bd33",
                            Name = "Guardian",
                            NormalizedName = "GUARDIAN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NABD.Models.Domain.Emergency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EmergencyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmergencyDetails")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("GuardianId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicalStaffId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuardianId");

                    b.HasIndex("MedicalStaffId");

                    b.HasIndex("PatientId");

                    b.HasIndex("ToolId");

                    b.ToTable("Emergencies");
                });

            modelBuilder.Entity("NABD.Models.Domain.Guardian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("NABD.Models.Domain.MedicalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Medication")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalHistory");
                });

            modelBuilder.Entity("NABD.Models.Domain.MedicalStaff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PersonalImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SSN")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MedicalStaff");

                    b.HasDiscriminator().HasValue("MedicalStaff");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("NABD.Models.Domain.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuardianId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicalStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ToolId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuardianId");

                    b.HasIndex("MedicalStaffId");

                    b.HasIndex("PatientId");

                    b.HasIndex("ToolId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("NABD.Models.Domain.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PersonalImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("NABD.Models.Domain.PatientDoctor", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("PatientDoctors");
                });

            modelBuilder.Entity("NABD.Models.Domain.PatientGuardian", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("GuardianId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "GuardianId");

                    b.HasIndex("GuardianId");

                    b.ToTable("PatientGuardians");
                });

            modelBuilder.Entity("NABD.Models.Domain.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MedicalStaffId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("ReportDetails")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedicalStaffId");

                    b.HasIndex("PatientId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("NABD.Models.Domain.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("BodyTemperature")
                        .HasColumnType("real");

                    b.Property<int>("HeartRate")
                        .HasColumnType("int");

                    b.Property<int>("OxygenSaturation")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("QrCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("VitalDataTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique()
                        .HasFilter("[PatientId] IS NOT NULL");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("NABD.Models.Domain.Doctor", b =>
                {
                    b.HasBaseType("NABD.Models.Domain.MedicalStaff");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("NABD.Models.Domain.Nurse", b =>
                {
                    b.HasBaseType("NABD.Models.Domain.MedicalStaff");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DoctorId");

                    b.HasDiscriminator().HasValue("Nurse");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NABD.Models.Domain.Emergency", b =>
                {
                    b.HasOne("NABD.Models.Domain.Guardian", "Guardian")
                        .WithMany("Emergencies")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NABD.Models.Domain.MedicalStaff", "MedicalStaff")
                        .WithMany("Emergencies")
                        .HasForeignKey("MedicalStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NABD.Models.Domain.Patient", "Patient")
                        .WithMany("Emergencies")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NABD.Models.Domain.Tool", "Tool")
                        .WithMany("Emergencies")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Guardian");

                    b.Navigation("MedicalStaff");

                    b.Navigation("Patient");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("NABD.Models.Domain.MedicalHistory", b =>
                {
                    b.HasOne("NABD.Models.Domain.Patient", "Patient")
                        .WithOne("MedicalHistory")
                        .HasForeignKey("NABD.Models.Domain.MedicalHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("NABD.Models.Domain.Notification", b =>
                {
                    b.HasOne("NABD.Models.Domain.Guardian", "Guardian")
                        .WithMany("Notifications")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NABD.Models.Domain.MedicalStaff", "MedicalStaff")
                        .WithMany("Notifications")
                        .HasForeignKey("MedicalStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NABD.Models.Domain.Patient", "Patient")
                        .WithMany("Notifications")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NABD.Models.Domain.Tool", "Tool")
                        .WithMany("Notifications")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Guardian");

                    b.Navigation("MedicalStaff");

                    b.Navigation("Patient");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("NABD.Models.Domain.PatientDoctor", b =>
                {
                    b.HasOne("NABD.Models.Domain.Doctor", "Doctor")
                        .WithMany("PatientDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NABD.Models.Domain.Patient", "Patient")
                        .WithMany("PatientDoctors")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("NABD.Models.Domain.PatientGuardian", b =>
                {
                    b.HasOne("NABD.Models.Domain.Guardian", "Guardian")
                        .WithMany("PatientGuardians")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NABD.Models.Domain.Patient", "Patient")
                        .WithMany("PatientGuardians")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guardian");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("NABD.Models.Domain.Report", b =>
                {
                    b.HasOne("NABD.Models.Domain.MedicalStaff", "MedicalStaff")
                        .WithMany("Reports")
                        .HasForeignKey("MedicalStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NABD.Models.Domain.Patient", "Patient")
                        .WithMany("Reports")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("MedicalStaff");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("NABD.Models.Domain.Tool", b =>
                {
                    b.HasOne("NABD.Models.Domain.Patient", "Patient")
                        .WithOne("Tool")
                        .HasForeignKey("NABD.Models.Domain.Tool", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("NABD.Models.Domain.Nurse", b =>
                {
                    b.HasOne("NABD.Models.Domain.Doctor", "Doctor")
                        .WithMany("Nurses")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("NABD.Models.Domain.Guardian", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("Notifications");

                    b.Navigation("PatientGuardians");
                });

            modelBuilder.Entity("NABD.Models.Domain.MedicalStaff", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("Notifications");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("NABD.Models.Domain.Patient", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("MedicalHistory")
                        .IsRequired();

                    b.Navigation("Notifications");

                    b.Navigation("PatientDoctors");

                    b.Navigation("PatientGuardians");

                    b.Navigation("Reports");

                    b.Navigation("Tool")
                        .IsRequired();
                });

            modelBuilder.Entity("NABD.Models.Domain.Tool", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("NABD.Models.Domain.Doctor", b =>
                {
                    b.Navigation("Nurses");

                    b.Navigation("PatientDoctors");
                });
#pragma warning restore 612, 618
        }
    }
}
