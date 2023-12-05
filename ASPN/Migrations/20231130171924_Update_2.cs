using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPN.Migrations {
    /// <inheritdoc />
    public partial class Update_2:Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fe1d4fc-d6ea-43c7-a1f4-73d2f83032bd",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "883a8105-0c9f-4608-8f42-5a99fe32cc55", new DateTime(2023, 11, 30, 16, 35, 17, 572, DateTimeKind.Utc).AddTicks(9182), "AQAAAAIAAYagAAAAEKlisc9+WMMiZHXh5Q/xgZfqaS1kL1PBPTlTWnMxeIY53S+R1WY6KQkjW+prdWbSsQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97ed420-63cd-43cd-814f-2bee8c0f46d4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "4c64b175-0f35-4530-907a-87904b8e382c", new DateTime(2023, 11, 30, 16, 35, 17, 485, DateTimeKind.Utc).AddTicks(345), "AQAAAAIAAYagAAAAEBZoAi7QTDX8G6CcqvVBPY3UCe7/TqIeDcJ4hccKeryhpRFDpsuevilJKOhQ9t/DnA==" });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("520661c1-0236-42e9-8d5d-c8d74700624c"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 30, 16, 35, 17, 659, DateTimeKind.Utc).AddTicks(7145));
        }
    }
}
