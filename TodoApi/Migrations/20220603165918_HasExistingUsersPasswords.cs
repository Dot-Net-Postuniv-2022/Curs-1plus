using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    public partial class HasExistingUsersPasswords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 6, 3, 19, 59, 17, 700, DateTimeKind.Local).AddTicks(9970), "AQAAAAEAACcQAAAAEHLxWiKUiu5GM8yKKrFhhEvSGNNJEnZggLW2XaAjYOno5F/NJ1XWHp8E+Pn7RC94Gg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 6, 3, 18, 5, 8, 743, DateTimeKind.Local).AddTicks(9320), "admin" });
        }
    }
}
