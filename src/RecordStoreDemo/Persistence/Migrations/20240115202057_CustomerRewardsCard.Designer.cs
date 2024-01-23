﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecordStoreDemo.Persistence;

#nullable disable

namespace RecordStoreDemo.Persistence.Migrations
{
    [DbContext(typeof(RecordStoreDbContext))]
    [Migration("20240115202057_CustomerRewardsCard")]
    partial class CustomerRewardsCard
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecordStoreDemo.Features.Customers.Profiles.CustomerProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<Guid>("RewardsCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RewardsCardId");

                    b.ToTable("CustomerProfiles");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Customers.Rewards.RewardsCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RewardsCards");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Customers.SpecialOrders.SpecialOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Contacted")
                        .HasColumnType("bit");

                    b.Property<Guid>("CustomerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InventoryProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerProfileId");

                    b.HasIndex("InventoryProductId");

                    b.ToTable("SpecialOrders");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Inventory.Products.InventoryProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("CatalogProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OnHand")
                        .HasColumnType("int");

                    b.Property<DateTime>("StreetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CatalogProductId");

                    b.ToTable("InventoryProducts");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Inventory.Products.OnHandChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("InventoryProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NewOnHand")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityChange")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InventoryProductId");

                    b.ToTable("OnHandHistory");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Inventory.Products.PriceChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("InventoryProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InventoryProductId");

                    b.ToTable("PriceHistory");
                });

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

            modelBuilder.Entity("RecordStoreDemo.Features.Receiving.Receive", b =>
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

                    b.Property<Guid>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Receives");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Receiving.ReceiveItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatalogProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InventoryProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ReceiveId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CatalogProductId");

                    b.HasIndex("InventoryProductId");

                    b.HasIndex("ReceiveId");

                    b.ToTable("ReceiveItem");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Customers.Profiles.CustomerProfile", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Customers.Rewards.RewardsCard", "RewardsCard")
                        .WithMany()
                        .HasForeignKey("RewardsCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.EmailAddress", "EmailAddress", b1 =>
                        {
                            b1.Property<Guid>("CustomerProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EmailAddress");

                            b1.HasKey("CustomerProfileId");

                            b1.ToTable("CustomerProfiles");

                            b1.WithOwner()
                                .HasForeignKey("CustomerProfileId");
                        });

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("CustomerProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Digits")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("CustomerProfileId");

                            b1.ToTable("CustomerProfiles");

                            b1.WithOwner()
                                .HasForeignKey("CustomerProfileId");
                        });

                    b.Navigation("EmailAddress");

                    b.Navigation("PhoneNumber");

                    b.Navigation("RewardsCard");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Customers.SpecialOrders.SpecialOrder", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Customers.Profiles.CustomerProfile", "CustomerProfile")
                        .WithMany("SpecialOrders")
                        .HasForeignKey("CustomerProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecordStoreDemo.Features.Inventory.Products.InventoryProduct", "Product")
                        .WithMany()
                        .HasForeignKey("InventoryProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerProfile");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Inventory.Products.InventoryProduct", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Purchasing.Catalogs.CatalogProduct", "CatalogProduct")
                        .WithMany()
                        .HasForeignKey("CatalogProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.Category", "Category", b1 =>
                        {
                            b1.Property<Guid>("InventoryProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Department")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Department");

                            b1.Property<string>("Format")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Format");

                            b1.HasKey("InventoryProductId");

                            b1.ToTable("InventoryProducts");

                            b1.WithOwner()
                                .HasForeignKey("InventoryProductId");
                        });

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("InventoryProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(8,2)")
                                .HasColumnName("Price");

                            b1.HasKey("InventoryProductId");

                            b1.ToTable("InventoryProducts");

                            b1.WithOwner()
                                .HasForeignKey("InventoryProductId");
                        });

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.UPC", "UPC", b1 =>
                        {
                            b1.Property<Guid>("InventoryProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UPC");

                            b1.HasKey("InventoryProductId");

                            b1.ToTable("InventoryProducts");

                            b1.WithOwner()
                                .HasForeignKey("InventoryProductId");
                        });

                    b.Navigation("CatalogProduct");

                    b.Navigation("Category")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("UPC")
                        .IsRequired();
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Inventory.Products.OnHandChange", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Inventory.Products.InventoryProduct", null)
                        .WithMany("OnHandHistory")
                        .HasForeignKey("InventoryProductId");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Inventory.Products.PriceChange", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Inventory.Products.InventoryProduct", null)
                        .WithMany("PriceHistory")
                        .HasForeignKey("InventoryProductId");

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.Price", "NewPrice", b1 =>
                        {
                            b1.Property<Guid>("PriceChangeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(8,2)")
                                .HasColumnName("New Price");

                            b1.HasKey("PriceChangeId");

                            b1.ToTable("PriceHistory");

                            b1.WithOwner()
                                .HasForeignKey("PriceChangeId");
                        });

                    b.OwnsOne("RecordStoreDemo.Common.ValueObjects.Price", "OldPrice", b1 =>
                        {
                            b1.Property<Guid>("PriceChangeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(8,2)")
                                .HasColumnName("Old Price");

                            b1.HasKey("PriceChangeId");

                            b1.ToTable("PriceHistory");

                            b1.WithOwner()
                                .HasForeignKey("PriceChangeId");
                        });

                    b.Navigation("NewPrice")
                        .IsRequired();

                    b.Navigation("OldPrice")
                        .IsRequired();
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

            modelBuilder.Entity("RecordStoreDemo.Features.Receiving.ReceiveItem", b =>
                {
                    b.HasOne("RecordStoreDemo.Features.Purchasing.Catalogs.CatalogProduct", "CatalogProduct")
                        .WithMany()
                        .HasForeignKey("CatalogProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecordStoreDemo.Features.Inventory.Products.InventoryProduct", "InventoryProduct")
                        .WithMany()
                        .HasForeignKey("InventoryProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecordStoreDemo.Features.Receiving.Receive", null)
                        .WithMany("Items")
                        .HasForeignKey("ReceiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogProduct");

                    b.Navigation("InventoryProduct");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Customers.Profiles.CustomerProfile", b =>
                {
                    b.Navigation("SpecialOrders");
                });

            modelBuilder.Entity("RecordStoreDemo.Features.Inventory.Products.InventoryProduct", b =>
                {
                    b.Navigation("OnHandHistory");

                    b.Navigation("PriceHistory");
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

            modelBuilder.Entity("RecordStoreDemo.Features.Receiving.Receive", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
