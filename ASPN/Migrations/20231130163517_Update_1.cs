using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPN.Migrations
{
    /// <inheritdoc />
    public partial class Update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Author", "CodeWord", "CreatedAt", "Description", "ImagePath", "Text", "Title" },
                values: new object[] { new Guid("520661c1-0236-42e9-8d5d-c8d74700624c"), null, "TestPageFromDB", new DateTime(2023, 11, 30, 16, 35, 17, 659, DateTimeKind.Utc).AddTicks(7145), "Test page from db", null, "<p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Alias eligendi ex voluptatum rem illo sint nisi harum consequatur, magnam itaque fugit nam deserunt nulla nobis veniam blanditiis beatae exercitationem, minus perspiciatis consectetur temporibus repellendus. Odio, mollitia, vel, accusantium officiis minus vero nobis est nisi repudiandae exercitationem ipsa distinctio dolorum. Iure!</p>\r\n\r\n<p>@Model.CreatedAt</p>", "Hellow page from DB" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fe1d4fc-d6ea-43c7-a1f4-73d2f83032bd",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "a60d1ad8-bc87-4252-9bc6-4017e703a9f5", new DateTime(2023, 11, 29, 8, 29, 56, 752, DateTimeKind.Utc).AddTicks(8417), "AQAAAAIAAYagAAAAEG7W7WWGTlY4RcK0fQh8OPx6woL7h9FAyNy7nJZbhnqX5gb+txC6W0aRz/3CHncHhg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97ed420-63cd-43cd-814f-2bee8c0f46d4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "5db4bce8-297b-4b0c-ae35-08a17eced625", new DateTime(2023, 11, 29, 8, 29, 56, 595, DateTimeKind.Utc).AddTicks(5943), "AQAAAAIAAYagAAAAEG6kH0zWEOngdsgK5LAu9z8+tUho660DeojppWweweQq/DeoBiIVpVAJoWHwUAM64A==" });
        }
    }
}
