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
                name: "Attributes",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    DisplayType = table.Column<short>(type: "smallint", nullable: false)
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true)
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
                    Name = table.Column<string>(type: "text", nullable: true),
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
                name: "Templates",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptions",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    AttributeId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TemplateGroups",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupName = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateGroups_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalSchema: "catalog_v1",
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateGroupItems",
                schema: "catalog_v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateGroupItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateGroupItems_TemplateGroups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "catalog_v1",
                        principalTable: "TemplateGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateGroupItems_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalSchema: "catalog_v1",
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGroupItems_GroupId",
                schema: "catalog_v1",
                table: "TemplateGroupItems",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGroupItems_TemplateId",
                schema: "catalog_v1",
                table: "TemplateGroupItems",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGroups_TemplateId",
                schema: "catalog_v1",
                table: "TemplateGroups",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "TemplateGroupItems",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "TemplateGroups",
                schema: "catalog_v1");

            migrationBuilder.DropTable(
                name: "Templates",
                schema: "catalog_v1");
        }
    }
}
