﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecordStoreDemo.Persistence;

#nullable disable

namespace RecordStoreDemo.Persistence.Migrations
{
    [DbContext(typeof(RecordStoreDbContext))]
    partial class RecordStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.Catalogs.Catalog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArtistColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormatColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasHeader")
                        .HasColumnType("bit");

                    b.Property<string>("LabelColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SKUColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetDateColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPCColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VendorId")
                        .IsUnique();

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.Catalogs.CatalogProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("CartQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderedQuantity")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StreetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("CatalogProducts");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.PurchaseOrders.PurchaseOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(8,2)");

                    b.Property<Guid>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.PurchaseOrders.PurchaseOrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatalogProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PurchaseOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogProductId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseOrderItems");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.Vendors.Vendor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.Catalogs.Catalog", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Purchasing.Vendors.Vendor", null)
                        .WithOne("Catalog")
                        .HasForeignKey("RecordStoreDemo.Features.Purchasing.Catalogs.Catalog", "VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.Catalogs.CatalogProduct", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Purchasing.Vendors.Vendor", null)
                        .WithMany("Products")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.Price", "Cost", b1 =>
                        {
                            b1.Property<Guid>("CatalogProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(8,2)")
                                .HasColumnName("Cost");

                            b1.HasKey("CatalogProductId");

                            b1.ToTable("CatalogProducts");

                            b1.WithOwner()
                                .HasForeignKey("CatalogProductId");
                        });

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.UPC", "UPC", b1 =>
                        {
                            b1.Property<Guid>("CatalogProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UPC");

                            b1.HasKey("CatalogProductId");

                            b1.ToTable("CatalogProducts");

                            b1.WithOwner()
                                .HasForeignKey("CatalogProductId");
                        });

                    b.Navigation("Cost")
                        .IsRequired();

                    b.Navigation("UPC")
                        .IsRequired();
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.PurchaseOrders.PurchaseOrder", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Purchasing.Vendors.Vendor", "Vendor")
                        .WithMany("Orders")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.PurchaseOrders.PurchaseOrderItem", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Purchasing.Catalogs.CatalogProduct", "CatalogProduct")
                        .WithMany()
                        .HasForeignKey("CatalogProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecordStoreDemo.Features.Purchasing.PurchaseOrders.PurchaseOrder", null)
                        .WithMany("Items")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogProduct");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.PurchaseOrders.PurchaseOrder", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Purchasing.Vendors.Vendor", b =>
                {
                    b.Navigation("Catalog")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
