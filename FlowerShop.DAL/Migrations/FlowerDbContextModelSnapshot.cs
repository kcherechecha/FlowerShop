﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlowerShop.DAL.Migrations
{
    [DbContext(typeof(FlowerDbContext))]
    partial class FlowerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Baskets", (string)null);
                });

            modelBuilder.Entity("Bouquet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Bouquets", (string)null);
                });

            modelBuilder.Entity("BouquetBasket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BouquetId")
                        .HasColumnType("uuid");

                    b.HasKey("BasketId", "BouquetId");

                    b.HasIndex("BouquetId");

                    b.ToTable("BouquetBaskets", (string)null);
                });

            modelBuilder.Entity("BouquetWishlist", b =>
                {
                    b.Property<Guid>("BouquetId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WishlistId")
                        .HasColumnType("uuid");

                    b.HasKey("BouquetId", "WishlistId");

                    b.HasIndex("WishlistId");

                    b.ToTable("BouquetWishlists", (string)null);
                });

            modelBuilder.Entity("Flower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Flowers", (string)null);
                });

            modelBuilder.Entity("FlowerBouquet", b =>
                {
                    b.Property<Guid>("FlowerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BouquetId")
                        .HasColumnType("uuid");

                    b.HasKey("FlowerId", "BouquetId");

                    b.HasIndex("BouquetId");

                    b.ToTable("FlowerBouquets", (string)null);
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uuid");

                    b.Property<string>("OrderAddress")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses", (string)null);
                });

            modelBuilder.Entity("Wishlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Wishlists", (string)null);
                });

            modelBuilder.Entity("Basket", b =>
                {
                    b.HasOne("Order", "Order")
                        .WithOne("Basket")
                        .HasForeignKey("Basket", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BouquetBasket", b =>
                {
                    b.HasOne("Basket", "Basket")
                        .WithMany("BouquetBaskets")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bouquet", "Bouquet")
                        .WithMany("BouquetBaskets")
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Bouquet");
                });

            modelBuilder.Entity("BouquetWishlist", b =>
                {
                    b.HasOne("Bouquet", "Bouquet")
                        .WithMany("BouquetWishlists")
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wishlist", "Wishlist")
                        .WithMany("BouquetWishlists")
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bouquet");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("FlowerBouquet", b =>
                {
                    b.HasOne("Bouquet", "Bouquet")
                        .WithMany("FlowerBouquets")
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flower", "Flower")
                        .WithMany("FlowerBouquets")
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bouquet");

                    b.Navigation("Flower");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("Basket", b =>
                {
                    b.Navigation("BouquetBaskets");
                });

            modelBuilder.Entity("Bouquet", b =>
                {
                    b.Navigation("BouquetBaskets");

                    b.Navigation("BouquetWishlists");

                    b.Navigation("FlowerBouquets");
                });

            modelBuilder.Entity("Flower", b =>
                {
                    b.Navigation("FlowerBouquets");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Navigation("Basket");
                });

            modelBuilder.Entity("Wishlist", b =>
                {
                    b.Navigation("BouquetWishlists");
                });
#pragma warning restore 612, 618
        }
    }
}