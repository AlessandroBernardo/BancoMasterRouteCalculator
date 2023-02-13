using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initialWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Origin = table.Column<string>(type: "varchar(3)", nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Destination", "Origin", "Value" },
                values: new object[,]
                {
                    { new Guid("541a18d4-2ba8-4a6e-addb-6ff8670023bb"), "BRC", "GRU", 10m },
                    { new Guid("2fcb9645-28d5-4cd3-a09c-c9b657676d26"), "SCL", "BRC", 5m },
                    { new Guid("6644f2c0-035e-426a-bc7a-42419337f60e"), "CDG", "GRU", 75m },
                    { new Guid("04c490f6-41eb-4202-8264-35a60d3f1454"), "SCL", "GRU", 20m },
                    { new Guid("e386472f-0de9-419a-b118-13806fe5e0b9"), "ORL", "GRU", 56m },
                    { new Guid("5cf3653c-4497-49b1-a831-0ddb1de869b9"), "CDG", "ORL", 5m },
                    { new Guid("498566a5-7235-43cd-ab88-d301430b2034"), "ORL", "SCL", 20m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Route");
        }
    }
}
