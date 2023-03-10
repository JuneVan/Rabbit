﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rabbit.Catalog.Infrastructure.EntityFrameworkCore;

#nullable disable

namespace Rabbit.Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20230309123300_init-catalog")]
    partial class initcatalog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("catalog_v1")
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<short>("DisplayType")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Attributes", "catalog_v1");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.AttributeAggregate.AttributeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeId")
                        .HasColumnType("integer");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.ToTable("AttributeOptions", "catalog_v1");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.BrandAggregate.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brands", "catalog_v1");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.CategoryAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer")
                        .HasComment("创建人的用户Id");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("删除时间");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("integer")
                        .HasComment("删除人的用户Id");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasComment("是否已被删除");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("integer")
                        .HasComment("最后更新人的用户Id");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories", "catalog_v1");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.TemplateAggregate.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Templates", "catalog_v1");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.TemplateAggregate.TemplateGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.Property<int>("TemplateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateGroups", "catalog_v1");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.TemplateAggregate.TemplateGroupItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeId")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("TemplateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateGroupItems", "catalog_v1");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.AttributeAggregate.AttributeOption", b =>
                {
                    b.HasOne("Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute", null)
                        .WithMany("Options")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.CategoryAggregate.Category", b =>
                {
                    b.HasOne("Rabbit.Catalog.AggregateModels.CategoryAggregate.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.TemplateAggregate.TemplateGroup", b =>
                {
                    b.HasOne("Rabbit.Catalog.AggregateModels.TemplateAggregate.Template", null)
                        .WithMany("Groups")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.TemplateAggregate.TemplateGroupItem", b =>
                {
                    b.HasOne("Rabbit.Catalog.AggregateModels.TemplateAggregate.TemplateGroup", null)
                        .WithMany("Items")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rabbit.Catalog.AggregateModels.TemplateAggregate.Template", null)
                        .WithMany("Items")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.CategoryAggregate.Category", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.TemplateAggregate.Template", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("Rabbit.Catalog.AggregateModels.TemplateAggregate.TemplateGroup", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}