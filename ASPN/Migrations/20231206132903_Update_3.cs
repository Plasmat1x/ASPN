using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPN.Migrations
{
    /// <inheritdoc />
    public partial class Update_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "itemImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fe1d4fc-d6ea-43c7-a1f4-73d2f83032bd",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "505beaac-f6f0-4cb4-8361-e0bcbd9a441b", new DateTime(2023, 12, 6, 13, 29, 0, 410, DateTimeKind.Utc).AddTicks(4774), "AQAAAAIAAYagAAAAEGN6AB7WyvhoYq6kwef38GsYILRZnwTjA0408+HoqWtqMXS+QMzosSdadBqXrNactQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97ed420-63cd-43cd-814f-2bee8c0f46d4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "c7078d03-0501-407b-8653-a11a4ce0b7e5", new DateTime(2023, 12, 6, 13, 29, 0, 320, DateTimeKind.Utc).AddTicks(1576), "AQAAAAIAAYagAAAAEFh+5+WNwWu3RF9JRJ4wmCb5iZoWFwbu37CyEhLkTXXL9dsYhTRRg7VByd+8vjUG8w==" });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("520661c1-0236-42e9-8d5d-c8d74700624c"),
                column: "CreatedAt",
                value: new DateTime(2023, 12, 6, 13, 29, 0, 506, DateTimeKind.Utc).AddTicks(5733));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "itemImages");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fe1d4fc-d6ea-43c7-a1f4-73d2f83032bd",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "73bf0d80-282c-430a-963e-531fde1426da", new DateTime(2023, 11, 30, 17, 19, 24, 607, DateTimeKind.Utc).AddTicks(4433), "AQAAAAIAAYagAAAAEIkW1Etv8IC2AdHcrfB/viYMVrwIVdLDm9WFfzkEFUKJs04EklG0OJzBj6xpOBrYiw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97ed420-63cd-43cd-814f-2bee8c0f46d4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "48110939-23e3-471d-8c73-7d8c14bcd3f6", new DateTime(2023, 11, 30, 17, 19, 24, 523, DateTimeKind.Utc).AddTicks(3133), "AQAAAAIAAYagAAAAEERdm68e0KU2AU2hMGZppRjhgsHqdCR/BLxE/inzn7a7gM2JLRXn8Q4p59EYAmMdPQ==" });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("520661c1-0236-42e9-8d5d-c8d74700624c"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 30, 17, 19, 24, 705, DateTimeKind.Utc).AddTicks(2596));
        }
    }
}
