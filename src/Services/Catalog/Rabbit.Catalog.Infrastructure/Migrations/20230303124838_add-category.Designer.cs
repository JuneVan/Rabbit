﻿// <auto-generated />
using System;
using Rabbit.Catalog.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rabbit.Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20230303124838_add-category")]
    partial class addcategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.CategoryAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("_displayOrder")
                        .HasColumnType("integer")
                        .HasColumnName("DisplayOrder");

                    b.Property<string>("_name")
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int?>("_parentId")
                        .HasColumnType("integer")
                        .HasColumnName("ParentId");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
