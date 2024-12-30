﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241230160236_mig15")]
    partial class mig15
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concrete.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("AppointmentTime")
                        .HasColumnType("time");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("AppointmentID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Checkup", b =>
                {
                    b.Property<int>("CheckupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CheckupID"));

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CheckupID");

                    b.ToTable("Checkups");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Clinic", b =>
                {
                    b.Property<int>("ClinicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClinicID");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"));

                    b.Property<int>("ClinicID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorID");

                    b.HasIndex("ClinicID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("EntityLayer.Concrete.PatientAnswers", b =>
                {
                    b.Property<int>("PatientAnswersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientAnswersID"));

                    b.Property<bool>("Answer")
                        .HasColumnType("bit");

                    b.Property<int>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<int>("CheckupID")
                        .HasColumnType("int");

                    b.Property<string>("PdfFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientAnswersID");

                    b.HasIndex("AppointmentID");

                    b.HasIndex("CheckupID");

                    b.ToTable("PatientAnswers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Prescription", b =>
                {
                    b.Property<int>("PrescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescriptionID"));

                    b.Property<int>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("PrescriptionID");

                    b.HasIndex("AppointmentID");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Appointment", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Doctor", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Clinic", "Clinic")
                        .WithMany("Doctors")
                        .HasForeignKey("ClinicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("EntityLayer.Concrete.PatientAnswers", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Appointment", "Appointment")
                        .WithMany("PatientAnswers")
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Checkup", "Checkup")
                        .WithMany("PatientAnswers")
                        .HasForeignKey("CheckupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Checkup");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Prescription", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Appointment", "Appointment")
                        .WithMany("Prescriptions")
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Appointment", b =>
                {
                    b.Navigation("PatientAnswers");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Checkup", b =>
                {
                    b.Navigation("PatientAnswers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Clinic", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
