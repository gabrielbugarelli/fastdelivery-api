using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastDelivery.Infrastructure.Migrations
{
    public partial class ProductsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, nullable: false),
                    Description = table.Column<string>(type: "varchar(700)", unicode: false, nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Registration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    QuantityStock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
