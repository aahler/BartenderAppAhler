﻿// <auto-generated />
using System;
using BartenderApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BartenderApp.Migrations
{
    [DbContext(typeof(BartenderAppContext))]
    [Migration("20190820030259_update1")]
    partial class update1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BartenderApp.Models.Cocktails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CocktailName");

                    b.Property<double>("CocktailPrice");

                    b.Property<int?>("OrdersID");

                    b.HasKey("ID");

                    b.HasIndex("OrdersID");

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("BartenderApp.Models.Orders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BartenderApp.Models.Cocktails", b =>
                {
                    b.HasOne("BartenderApp.Models.Orders")
                        .WithMany("Cocktails")
                        .HasForeignKey("OrdersID");
                });
#pragma warning restore 612, 618
        }
    }
}