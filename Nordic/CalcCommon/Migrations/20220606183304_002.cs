using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calculator.Common.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    ID = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    MaterialID = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    Amount = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderLines_Materials_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_MaterialID",
                table: "OrderLines",
                column: "MaterialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");
        }
    }
}
