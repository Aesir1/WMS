﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseInfrastructure.Contexts;

#nullable disable

namespace WarehouseInfrastructure.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    [Migration("20221103135806_UserPermission")]
    partial class UserPermission
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DepartmentUser", b =>
                {
                    b.Property<Guid>("DepartmentsGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentsGuid", "UsersGuid");

                    b.HasIndex("UsersGuid");

                    b.ToTable("DepartmentUser");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Organisation.Department", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Organisation.Permission", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Create")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Delete")
                        .HasColumnType("bit");

                    b.Property<bool>("Modified")
                        .HasColumnType("bit");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<bool>("UserManager")
                        .HasColumnType("bit");

                    b.HasKey("Guid");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Product.Article", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DimensionCodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HeavinessCodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("DimensionCodeId");

                    b.HasIndex("HeavinessCodeId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Storage.Address", b =>
                {
                    b.Property<string>("CodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Storage.Container", b =>
                {
                    b.Property<int>("ContainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContainerId"), 1L, 1);

                    b.Property<string>("AddressCodeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ArticleGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("ContainerId");

                    b.HasIndex("AddressCodeId");

                    b.HasIndex("ArticleGuid");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Unities.Dimension", b =>
                {
                    b.Property<string>("CodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Length")
                        .HasPrecision(9, 4)
                        .HasColumnType("decimal(9,4)");

                    b.Property<decimal>("Width")
                        .HasPrecision(9, 4)
                        .HasColumnType("decimal(9,4)");

                    b.HasKey("CodeId");

                    b.ToTable("Dimension");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Unities.Heaviness", b =>
                {
                    b.Property<string>("CodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("CodeId");

                    b.ToTable("Heaviness");
                });

            modelBuilder.Entity("WarehouseCore.Entities.User.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PermissionGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.HasIndex("PermissionGuid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WarehouseCore.Entities.User.UserInfo", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("DepartmentUser", b =>
                {
                    b.HasOne("WarehouseCore.Entities.Organisation.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseCore.Entities.User.User", null)
                        .WithMany()
                        .HasForeignKey("UsersGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WarehouseCore.Entities.Product.Article", b =>
                {
                    b.HasOne("WarehouseCore.Entities.Unities.Dimension", "Dimension")
                        .WithMany("Articles")
                        .HasForeignKey("DimensionCodeId");

                    b.HasOne("WarehouseCore.Entities.Unities.Heaviness", "Heaviness")
                        .WithMany("Articles")
                        .HasForeignKey("HeavinessCodeId");

                    b.Navigation("Dimension");

                    b.Navigation("Heaviness");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Storage.Container", b =>
                {
                    b.HasOne("WarehouseCore.Entities.Storage.Address", "Address")
                        .WithMany("Containers")
                        .HasForeignKey("AddressCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseCore.Entities.Product.Article", "Article")
                        .WithMany("Containers")
                        .HasForeignKey("ArticleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Article");
                });

            modelBuilder.Entity("WarehouseCore.Entities.User.User", b =>
                {
                    b.HasOne("WarehouseCore.Entities.User.UserInfo", "UserInfo")
                        .WithOne("User")
                        .HasForeignKey("WarehouseCore.Entities.User.User", "Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseCore.Entities.Organisation.Permission", "Permission")
                        .WithMany("Users")
                        .HasForeignKey("PermissionGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Organisation.Permission", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Product.Article", b =>
                {
                    b.Navigation("Containers");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Storage.Address", b =>
                {
                    b.Navigation("Containers");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Unities.Dimension", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("WarehouseCore.Entities.Unities.Heaviness", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("WarehouseCore.Entities.User.UserInfo", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
