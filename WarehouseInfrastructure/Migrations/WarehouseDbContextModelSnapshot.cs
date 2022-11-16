﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseInfrastructure.Contexts;

#nullable disable

namespace WarehouseInfrastructure.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    partial class WarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DepartmentUser", b =>
                {
                    b.Property<int>("DepartmentsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("DepartmentUser", (string)null);
                });

            modelBuilder.Entity("WarehouseCore.Entities.Organisation.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("WarehouseCore.Entities.Organisation.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasKey("Id");

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("WarehouseCore.Entities.Product.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasKey("Id");

                    b.HasIndex("DimensionCodeId");

                    b.HasIndex("HeavinessCodeId");

                    b.ToTable("Articles", (string)null);
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

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("WarehouseCore.Entities.Storage.Container", b =>
                {
                    b.Property<int>("ContainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContainerId"));

                    b.Property<string>("AddressCodeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("ContainerId");

                    b.HasIndex("AddressCodeId");

                    b.HasIndex("ArticleId");

                    b.ToTable("Containers", (string)null);
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

                    b.ToTable("Dimensions", (string)null);
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

                    b.ToTable("Heavinesses", (string)null);
                });

            modelBuilder.Entity("WarehouseCore.Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

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

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("WarehouseCore.Entities.User.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInfos", (string)null);
                });

            modelBuilder.Entity("DepartmentUser", b =>
                {
                    b.HasOne("WarehouseCore.Entities.Organisation.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseCore.Entities.User.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
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
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WarehouseCore.Entities.Product.Article", "Article")
                        .WithMany("Containers")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Article");
                });

            modelBuilder.Entity("WarehouseCore.Entities.User.User", b =>
                {
                    b.HasOne("WarehouseCore.Entities.User.UserInfo", "UserInfo")
                        .WithOne("User")
                        .HasForeignKey("WarehouseCore.Entities.User.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseCore.Entities.Organisation.Permission", "Permission")
                        .WithMany("Users")
                        .HasForeignKey("PermissionId")
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
