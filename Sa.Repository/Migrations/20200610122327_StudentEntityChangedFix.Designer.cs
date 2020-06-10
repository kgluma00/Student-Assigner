﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sa.Repository;

namespace Sa.Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200610122327_StudentEntityChangedFix")]
    partial class StudentEntityChangedFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SA.Core.Entites.Course", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("CourseName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SA.Core.Entites.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaOfInterestOne")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("AreaOfInterestThree")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("AreaOfInterestTwo")
                        .HasColumnType("varchar(20)");

                    b.Property<byte>("CourseId")
                        .HasColumnType("tinyint");

                    b.Property<float>("MaxPoints")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("SA.Core.Entites.Role", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("RoleName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SA.Core.Entites.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AverageGrade")
                        .HasColumnType("real");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(100)");

                    b.Property<byte>("CourseId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("NmbrOfRptYears")
                        .HasColumnType("tinyint");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.Property<byte>("StudyLevel")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SA.Core.Entites.StudentProfessorChoices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Factor")
                        .HasColumnType("tinyint");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StudentProfessorChoices");
                });

            modelBuilder.Entity("SA.Core.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryOfBirth")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(20)");

                    b.Property<byte>("RoleId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SA.Core.Entites.User", b =>
                {
                    b.HasOne("SA.Core.Entites.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
