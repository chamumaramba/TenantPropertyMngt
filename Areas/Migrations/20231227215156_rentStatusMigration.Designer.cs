﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TenantPropertyMngt.Data;

#nullable disable

namespace TenantPropertyMngt.Migrations
{
    [DbContext(typeof(TenantPropertyMngtDbContext))]
    [Migration("20231227215156_rentStatusMigration")]
    partial class rentStatusMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
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
                            Id = "fec5ff3f-8652-4ad9-b964-3217bf3d6e12",
                            Name = "admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "00263e71-1824-4ac3-bdd2-e43315f28b38",
                            Name = "agent",
                            NormalizedName = "agent"
                        },
                        new
                        {
                            Id = "786bc011-9f95-4e7b-8836-59883f81af35",
                            Name = "tenant",
                            NormalizedName = "tenant"
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PropertyModelTenantModel", b =>
                {
                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<int>("TenantsTenantID")
                        .HasColumnType("int");

                    b.HasKey("TenantID", "TenantsTenantID");

                    b.HasIndex("TenantsTenantID");

                    b.ToTable("TenantProperty", (string)null);
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.ApplicationUser", b =>
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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("TenantPropertyMngt.Models.LeaseModel", b =>
                {
                    b.Property<int>("LeaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaseID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeaseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyID")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rent")
                        .HasColumnType("decimal(18,0)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<string>("TenantName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaseID");

                    b.HasIndex("PropertyID");

                    b.HasIndex("TenantID");

                    b.ToTable("Leases");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.PropertyModel", b =>
                {
                    b.Property<int>("PropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyID"));

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PropertyOwnerID")
                        .HasColumnType("int");

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rent")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TenantID")
                        .HasColumnType("int");

                    b.HasKey("PropertyID");

                    b.HasIndex("PropertyOwnerID");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.PropertyOwnerModel", b =>
                {
                    b.Property<int>("PropertyOwnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyOwnerID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerIdCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropertyOwnerID");

                    b.ToTable("PropertiesOwners");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.RentPaymentModel", b =>
                {
                    b.Property<int>("RentPaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentPaymentID"));

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeaseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RentPaymentID");

                    b.HasIndex("LeaseID");

                    b.ToTable("RentPayments");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.TenantModel", b =>
                {
                    b.Property<int>("TenantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantID"));

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeaseModelLeaseID")
                        .HasColumnType("int");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PropertyID")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenantID");

                    b.HasIndex("LeaseModelLeaseID");

                    b.ToTable("Tenants");
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
                    b.HasOne("TenantPropertyMngt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TenantPropertyMngt.Models.ApplicationUser", null)
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

                    b.HasOne("TenantPropertyMngt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TenantPropertyMngt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PropertyModelTenantModel", b =>
                {
                    b.HasOne("TenantPropertyMngt.Models.PropertyModel", null)
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TenantPropertyMngt.Models.TenantModel", null)
                        .WithMany()
                        .HasForeignKey("TenantsTenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.LeaseModel", b =>
                {
                    b.HasOne("TenantPropertyMngt.Models.PropertyModel", "Properties")
                        .WithMany("Leases")
                        .HasForeignKey("PropertyID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TenantPropertyMngt.Models.TenantModel", "Tenant")
                        .WithMany("lease")
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Properties");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.PropertyModel", b =>
                {
                    b.HasOne("TenantPropertyMngt.Models.PropertyOwnerModel", "propertyOwner")
                        .WithMany("properties")
                        .HasForeignKey("PropertyOwnerID");

                    b.Navigation("propertyOwner");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.RentPaymentModel", b =>
                {
                    b.HasOne("TenantPropertyMngt.Models.LeaseModel", "Lease")
                        .WithMany("RentPayments")
                        .HasForeignKey("LeaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lease");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.TenantModel", b =>
                {
                    b.HasOne("TenantPropertyMngt.Models.LeaseModel", null)
                        .WithMany("Tenants")
                        .HasForeignKey("LeaseModelLeaseID");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.LeaseModel", b =>
                {
                    b.Navigation("RentPayments");

                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.PropertyModel", b =>
                {
                    b.Navigation("Leases");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.PropertyOwnerModel", b =>
                {
                    b.Navigation("properties");
                });

            modelBuilder.Entity("TenantPropertyMngt.Models.TenantModel", b =>
                {
                    b.Navigation("lease");
                });
#pragma warning restore 612, 618
        }
    }
}
