﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProfilesMicroService.Infrastructure;

#nullable disable

namespace ProfilesMicroService.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<string>("AccountPhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("CareerStartYear")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("uuid");

                    b.Property<string>("SpecializationName")
                        .HasColumnType("text");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<string>("AccountPhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsLinkedToAccount")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Receptionist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Receptionists");
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("242bb89f-149a-4cd0-b81f-55a378b8da3b"),
                            Name = "AtWork"
                        },
                        new
                        {
                            Id = new Guid("a6dee6ab-4edf-4006-8e2f-b8be6f842b86"),
                            Name = "OnVacation"
                        },
                        new
                        {
                            Id = new Guid("222ad367-3e96-41ad-b7e1-e6c3b31d408f"),
                            Name = "SickDay"
                        },
                        new
                        {
                            Id = new Guid("7a55ff1b-2e82-4db5-abfb-046128e395e0"),
                            Name = "SickLeave"
                        },
                        new
                        {
                            Id = new Guid("b9877be3-1b84-4083-a464-fb2c6dfda87d"),
                            Name = "SelfIsolation"
                        },
                        new
                        {
                            Id = new Guid("ceb6bc1e-cc2b-43ae-8243-b73fb11a4d0f"),
                            Name = "LeaveWithoutPay"
                        },
                        new
                        {
                            Id = new Guid("283f6717-6bbf-4b06-b960-2a2a6b727630"),
                            Name = "Inactive"
                        });
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Doctor", b =>
                {
                    b.HasOne("ProfilesMicroService.Domain.Entities.Models.Status", "Status")
                        .WithMany("Doctors")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Status", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
