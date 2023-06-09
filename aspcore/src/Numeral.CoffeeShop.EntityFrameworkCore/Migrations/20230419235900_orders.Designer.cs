﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Numeral.CoffeeShop.EntityFrameworkCore.Persistence;

#nullable disable

namespace Numeral.CoffeeShop.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(CoffeeShopDbContext))]
    [Migration("20230419235900_orders")]
    partial class orders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Numeral.CoffeeShop.Domain.CustomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Numeral.CoffeeShop.Domain.MenuItemAggregate.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<Guid>("LoyaltyProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems", (string)null);
                });

            modelBuilder.Entity("Numeral.CoffeeShop.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("OrderTotal")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Numeral.CoffeeShop.Domain.CustomerAggregate.Customer", b =>
                {
                    b.OwnsMany("Numeral.CoffeeShop.Domain.CustomerAggregate.Entities.Reward", "Rewards", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("RewardId");

                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CustomerRewardEnum")
                                .HasColumnType("int");

                            b1.Property<Guid>("LoyaltyProgramId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("Id", "CustomerId");

                            b1.HasIndex("CustomerId");

                            b1.ToTable("Rewards", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Rewards");
                });

            modelBuilder.Entity("Numeral.CoffeeShop.Domain.OrderAggregate.Order", b =>
                {
                    b.OwnsMany("Numeral.CoffeeShop.Domain.OrderAggregate.Entities.OrderItem", "OrderItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("OrderItemId");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id", "OrderId");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrderItems", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
