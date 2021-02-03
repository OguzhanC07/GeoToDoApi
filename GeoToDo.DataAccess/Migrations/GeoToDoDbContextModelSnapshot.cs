﻿// <auto-generated />
using System;
using GeoToDo.DataAccess.Concrete.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeoToDo.DataAccess.Migrations
{
    [DbContext(typeof(GeoToDoDbContext))]
    partial class GeoToDoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GeoToDo.Entities.Concrete.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhotoString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SelectedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.AppUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppRoleId");

                    b.HasIndex("AppUserId", "AppRoleId")
                        .IsUnique();

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.CategoryActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ActivityId", "CategoryId")
                        .IsUnique();

                    b.ToTable("CategoryActivities");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.SubActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ActivtyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ActivtyId");

                    b.ToTable("SubActivities");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("AchievedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("SavedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isAchieved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.Activity", b =>
                {
                    b.HasOne("GeoToDo.Entities.Concrete.AppUser", "AppUser")
                        .WithMany("Activities")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.AppUserRole", b =>
                {
                    b.HasOne("GeoToDo.Entities.Concrete.AppRole", "AppRole")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeoToDo.Entities.Concrete.AppUser", "AppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.Category", b =>
                {
                    b.HasOne("GeoToDo.Entities.Concrete.AppUser", "AppUser")
                        .WithMany("Categories")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.CategoryActivity", b =>
                {
                    b.HasOne("GeoToDo.Entities.Concrete.Activity", "Activity")
                        .WithMany("CategoryActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GeoToDo.Entities.Concrete.Category", "Category")
                        .WithMany("CategoryActivities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.SubActivity", b =>
                {
                    b.HasOne("GeoToDo.Entities.Concrete.Activity", "Activity")
                        .WithMany("SubActivities")
                        .HasForeignKey("ActivtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.Target", b =>
                {
                    b.HasOne("GeoToDo.Entities.Concrete.AppUser", "AppUser")
                        .WithMany("Targets")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.Activity", b =>
                {
                    b.Navigation("CategoryActivities");

                    b.Navigation("SubActivities");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.AppRole", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.AppUser", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("AppUserRoles");

                    b.Navigation("Categories");

                    b.Navigation("Targets");
                });

            modelBuilder.Entity("GeoToDo.Entities.Concrete.Category", b =>
                {
                    b.Navigation("CategoryActivities");
                });
#pragma warning restore 612, 618
        }
    }
}
