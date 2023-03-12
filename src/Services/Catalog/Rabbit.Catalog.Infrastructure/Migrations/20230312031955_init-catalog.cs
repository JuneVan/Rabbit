using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rabbit.Catalog.Infrastructure.Migrations
{
    public partial class initcatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog_v1");

            migrationBuilder.CreateTable(
                name: "AttributeGroups",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    ValueType = table.Column<int>(type: "integer", nullable: false),
                    ControlType = table.Column<short>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsSearch = table.Column<bool>(type: "boolean", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    AttributeType = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    CreatorUserId = table.Column<int>(type: "integer", nullable: false, comment: "创建人的用户Id"),
                    LastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "最后更新时间"),
                    LastModifierUserId = table.Column<int>(type: "integer", nullable: true, comment: "最后更新人的用户Id"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "是否已被删除"),
                    DeleterUserId = table.Column<int>(type: "integer", nullable: true, comment: "删除人的用户Id"),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Logo = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    CreatorUserId = table.Column<int>(type: "integer", nullable: false, comment: "创建人的用户Id"),
                    LastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "最后更新时间"),
                    LastModifierUserId = table.Column<int>(type: "integer", nullable: true, comment: "最后更新人的用户Id"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "是否已被删除"),
                    DeleterUserId = table.Column<int>(type: "integer", nullable: true, comment: "删除人的用户Id"),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "catalog_v1",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    CreatorUserId = table.Column<int>(type: "integer", nullable: false, comment: "创建人的用户Id"),
                    LastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "最后更新时间"),
                    LastModifierUserId = table.Column<int>(type: "integer", nullable: true, comment: "最后更新人的用户Id"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "是否已被删除"),
                    DeleterUserId = table.Column<int>(type: "integer", nullable: true, comment: "删除人的用户Id"),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeGroupItems",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeGroupId = table.Column<int>(type: "integer", nullable: false),
                    AttributeId = table.Column<int>(type: "integer", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroupItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeGroupItems_AttributeGroups_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalSchema: "catalog_v1",
                        principalTable: "AttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptions",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeOptions_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "catalog_v1",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeGroupItems_AttributeGroupId_AttributeId",
                schema: "catalog_v1",
                table: "AttributeGroupItems",
                columns: new[] { "AttributeGroupId", "AttributeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptions_AttributeId",
                schema: "catalog_v1",
                table: "AttributeOptions",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                schema: "catalog_v1",
                table: "Categories",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeGroupItems",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "AttributeOptions",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "AttributeGroups",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "catalog_v1");
        }
    }
}
