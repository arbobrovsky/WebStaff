﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20200314095006_number pricaz")]
    partial class numberpricaz
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entityes.Decree", b =>
                {
                    b.Property<int>("DecreeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("DecreeNumber");

                    b.Property<DateTime>("DecreeTime");

                    b.HasKey("DecreeId");

                    b.ToTable("Decrees");
                });

            modelBuilder.Entity("Data.Entityes.DecreeStaffs", b =>
                {
                    b.Property<int>("DecreeStaffsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DecreeId");

                    b.Property<int?>("FiredId");

                    b.Property<int>("StaffId");

                    b.Property<string>("Type");

                    b.HasKey("DecreeStaffsId");

                    b.HasIndex("DecreeId");

                    b.HasIndex("FiredId");

                    b.ToTable("DecreeStaffs");
                });

            modelBuilder.Entity("Data.Entityes.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Data.Entityes.Fired", b =>
                {
                    b.Property<int>("FiredId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FiredTime");

                    b.Property<string>("HowFired");

                    b.Property<int>("StaffId");

                    b.HasKey("FiredId");

                    b.HasIndex("StaffId");

                    b.ToTable("Fireds");
                });

            modelBuilder.Entity("Data.Entityes.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Data.Entityes.Rank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RankId");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("Data.Entityes.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Fired");

                    b.Property<string>("First");

                    b.Property<string>("MiddleName");

                    b.Property<int>("PositionId");

                    b.Property<int>("RankId");

                    b.Property<string>("Second");

                    b.Property<int>("SubDepartmenId");

                    b.HasKey("StaffId");

                    b.HasIndex("PositionId");

                    b.HasIndex("RankId");

                    b.HasIndex("SubDepartmenId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("Data.Entityes.SubDepartment", b =>
                {
                    b.Property<int>("SubDepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("Name");

                    b.HasKey("SubDepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("SubDepartments");
                });

            modelBuilder.Entity("Data.Entityes.DecreeStaffs", b =>
                {
                    b.HasOne("Data.Entityes.Decree", "Decree")
                        .WithMany("DecreeStaffs")
                        .HasForeignKey("DecreeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entityes.Fired", "Fired")
                        .WithMany()
                        .HasForeignKey("FiredId");
                });

            modelBuilder.Entity("Data.Entityes.Fired", b =>
                {
                    b.HasOne("Data.Entityes.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entityes.Staff", b =>
                {
                    b.HasOne("Data.Entityes.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entityes.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entityes.SubDepartment", "SubDepartmen")
                        .WithMany("Staffs")
                        .HasForeignKey("SubDepartmenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entityes.SubDepartment", b =>
                {
                    b.HasOne("Data.Entityes.Department")
                        .WithMany("SubDepartments")
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}