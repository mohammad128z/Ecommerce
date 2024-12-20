﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts.EF_Core;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Domain.Entities.DetailPreInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("PreInvoiceHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreInvoiceHeaderId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("DetailPreInvoice");
                });

            modelBuilder.Entity("Domain.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DetailPreInvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountAmount")
                        .HasColumnType("int");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<int>("PreInvoiceHeaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DetailPreInvoiceId");

                    b.HasIndex("PreInvoiceHeaderId");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("Domain.Entities.PreInvoiceHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("PreInvoiceHeader");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Domain.Entities.SalesLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalesLine");
                });

            modelBuilder.Entity("Domain.Entities.SalesLineInProduct", b =>
                {
                    b.Property<int>("SalesLineId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("SalesLineId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SalesLineInProduct");
                });

            modelBuilder.Entity("Domain.Entities.SalesLineInSeller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PreInvoiceHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("SalesLineId")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreInvoiceHeaderId")
                        .IsUnique();

                    b.HasIndex("SalesLineId");

                    b.HasIndex("SellerId");

                    b.ToTable("SalesLineInSeller");
                });

            modelBuilder.Entity("Domain.Entities.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("Domain.Entities.DetailPreInvoice", b =>
                {
                    b.HasOne("Domain.Entities.PreInvoiceHeader", "PreInvoiceHeader")
                        .WithOne("DetailPreInvoice")
                        .HasForeignKey("Domain.Entities.DetailPreInvoice", "PreInvoiceHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreInvoiceHeader");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.Discount", b =>
                {
                    b.HasOne("Domain.Entities.DetailPreInvoice", "DetailPreInvoice")
                        .WithMany("Discounts")
                        .HasForeignKey("DetailPreInvoiceId");

                    b.HasOne("Domain.Entities.PreInvoiceHeader", "PreInvoiceHeader")
                        .WithMany()
                        .HasForeignKey("PreInvoiceHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailPreInvoice");

                    b.Navigation("PreInvoiceHeader");
                });

            modelBuilder.Entity("Domain.Entities.PreInvoiceHeader", b =>
                {
                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.SalesLineInProduct", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SalesLine", "SalesLine")
                        .WithMany("SalesLineInProducts")
                        .HasForeignKey("SalesLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SalesLine");
                });

            modelBuilder.Entity("Domain.Entities.SalesLineInSeller", b =>
                {
                    b.HasOne("Domain.Entities.PreInvoiceHeader", "PreInvoiceHeader")
                        .WithOne("SalesLineInSeller")
                        .HasForeignKey("Domain.Entities.SalesLineInSeller", "PreInvoiceHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SalesLine", "SalesLine")
                        .WithMany("SalesLineInSellers")
                        .HasForeignKey("SalesLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Seller", "Seller")
                        .WithMany("SalesLineInSellers")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreInvoiceHeader");

                    b.Navigation("SalesLine");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Domain.Entities.DetailPreInvoice", b =>
                {
                    b.Navigation("Discounts");
                });

            modelBuilder.Entity("Domain.Entities.PreInvoiceHeader", b =>
                {
                    b.Navigation("DetailPreInvoice")
                        .IsRequired();

                    b.Navigation("SalesLineInSeller")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.SalesLine", b =>
                {
                    b.Navigation("SalesLineInProducts");

                    b.Navigation("SalesLineInSellers");
                });

            modelBuilder.Entity("Domain.Entities.Seller", b =>
                {
                    b.Navigation("SalesLineInSellers");
                });
#pragma warning restore 612, 618
        }
    }
}
