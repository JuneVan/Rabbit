using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rabbit.Catalog.Infrastructure.Migrations
{
    public partial class addcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
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
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
