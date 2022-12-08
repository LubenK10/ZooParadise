using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooParadise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ccf3f38-c3da-44c2-b658-a2030620bd8e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0796c23a-3349-4418-b841-5130cf1486ed", "AQAAAAEAACcQAAAAEMltvFrM4bPHWm6ofi1W6PlzYquhABdGtbhPFGGhvzdxcqXe0IwUmNO06P9bYbEHSQ==", "5bdc5729-3219-4af5-a862-ed983dd6f7a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83693954-c177-4804-a460-fa034d4b4616", "AQAAAAEAACcQAAAAEFhPyhWdM/KqunVanrbixN4fYS2OKVLhb7LPrWwe9tfyVuaeHy6fn3kT6rhz2tUkBw==", "8fd98e65-c110-44ec-8e7e-3bf0da7db257" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ccf3f38-c3da-44c2-b658-a2030620bd8e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddb8f0ae-0bcc-48a2-8c1d-89c3efefc08a", "AQAAAAEAACcQAAAAEIFwo3MjnM5IEsEncKKVlVmsw9FJ39zVf8ozlLAwVj2tCiZ0ylHosCY/CFk0xcYzPg==", "a2902aca-a5d5-4f27-82db-377f5c99839f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1527deb-7b4d-4d80-a068-e1406cdeb134", "AQAAAAEAACcQAAAAEGKBKP8WGJXFdsOFGzyS2CEm5xcxfUq6F5+h7HZOEfTUhr2oUg3vUN2SLL4+o0ueeQ==", "47169022-a733-48fd-bcdd-6f5ed1a88ea5" });
        }
    }
}
