﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20230212201841_alterValeuToPrice")]
    partial class alterValeuToPrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnName("Destination")
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnName("Origin")
                        .HasColumnType("varchar(3)");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Route");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fcdfb138-2a96-4534-9c17-f81452f65876"),
                            Destination = "BRC",
                            Origin = "GRU",
                            Price = 10m
                        },
                        new
                        {
                            Id = new Guid("ebc6b2af-b51b-47d5-ad67-ba1f95dbacf8"),
                            Destination = "SCL",
                            Origin = "BRC",
                            Price = 5m
                        },
                        new
                        {
                            Id = new Guid("8411cb45-6063-4318-b922-e5c6bcee4098"),
                            Destination = "CDG",
                            Origin = "GRU",
                            Price = 75m
                        },
                        new
                        {
                            Id = new Guid("d698b0f2-0a72-4aa8-8f7a-b794c3308ac8"),
                            Destination = "SCL",
                            Origin = "GRU",
                            Price = 20m
                        },
                        new
                        {
                            Id = new Guid("2b0fa84e-5ba4-4edf-85e4-c52d96eb1290"),
                            Destination = "ORL",
                            Origin = "GRU",
                            Price = 56m
                        },
                        new
                        {
                            Id = new Guid("2b51e339-c383-42f6-83a3-a561859645cc"),
                            Destination = "CDG",
                            Origin = "ORL",
                            Price = 5m
                        },
                        new
                        {
                            Id = new Guid("83bae63f-4a85-47ec-a72c-f8a571d9e0f5"),
                            Destination = "ORL",
                            Origin = "SCL",
                            Price = 20m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
