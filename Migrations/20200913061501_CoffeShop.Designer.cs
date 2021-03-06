﻿// <auto-generated />
using System;
using CoffeShop.EntitiesFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeShop.Migrations
{
    [DbContext(typeof(CoffeShopDbContext))]
    [Migration("20200913061501_CoffeShop")]
    partial class CoffeShop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeShop.Enties.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifierBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("_CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("_DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("_DeletedFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("_LastModifier")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CoffeShop.Enties.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifierBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("_CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("_DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("_DeletedFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("_LastModifier")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("CoffeShop.Enties.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifierBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<DateTime>("_CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("_DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("_DeletedFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("_LastModifier")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CoffeShop.Enties.OrderEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifierBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("_CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("_DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("_DeletedFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("_LastModifier")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("OrderEntry");
                });
#pragma warning restore 612, 618
        }
    }
}
