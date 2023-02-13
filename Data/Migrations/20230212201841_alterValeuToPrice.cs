using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class alterValeuToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("04c490f6-41eb-4202-8264-35a60d3f1454"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("2fcb9645-28d5-4cd3-a09c-c9b657676d26"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("498566a5-7235-43cd-ab88-d301430b2034"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("541a18d4-2ba8-4a6e-addb-6ff8670023bb"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("5cf3653c-4497-49b1-a831-0ddb1de869b9"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("6644f2c0-035e-426a-bc7a-42419337f60e"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("e386472f-0de9-419a-b118-13806fe5e0b9"));

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Route",
                newName: "Price");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Route",
                type: "varchar(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Destination", "Origin", "Price" },
                values: new object[,]
                {
                    { new Guid("fcdfb138-2a96-4534-9c17-f81452f65876"), "BRC", "GRU", 10m },
                    { new Guid("ebc6b2af-b51b-47d5-ad67-ba1f95dbacf8"), "SCL", "BRC", 5m },
                    { new Guid("8411cb45-6063-4318-b922-e5c6bcee4098"), "CDG", "GRU", 75m },
                    { new Guid("d698b0f2-0a72-4aa8-8f7a-b794c3308ac8"), "SCL", "GRU", 20m },
                    { new Guid("2b0fa84e-5ba4-4edf-85e4-c52d96eb1290"), "ORL", "GRU", 56m },
                    { new Guid("2b51e339-c383-42f6-83a3-a561859645cc"), "CDG", "ORL", 5m },
                    { new Guid("83bae63f-4a85-47ec-a72c-f8a571d9e0f5"), "ORL", "SCL", 20m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("2b0fa84e-5ba4-4edf-85e4-c52d96eb1290"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("2b51e339-c383-42f6-83a3-a561859645cc"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("83bae63f-4a85-47ec-a72c-f8a571d9e0f5"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("8411cb45-6063-4318-b922-e5c6bcee4098"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("d698b0f2-0a72-4aa8-8f7a-b794c3308ac8"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("ebc6b2af-b51b-47d5-ad67-ba1f95dbacf8"));

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("fcdfb138-2a96-4534-9c17-f81452f65876"));

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Route",
                newName: "Value");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)");

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
    }
}
