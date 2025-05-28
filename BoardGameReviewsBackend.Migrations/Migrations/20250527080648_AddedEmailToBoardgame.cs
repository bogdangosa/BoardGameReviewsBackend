using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameReviewsBackend.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailToBoardgame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isVerified",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                columns: new[] { "email", "isVerified" },
                values: new object[] { "admin@admin.com", true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                columns: new[] { "email", "isVerified" },
                values: new object[] { "john.doe@gmail.com", true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                columns: new[] { "email", "isVerified" },
                values: new object[] { "jane.smith@gmail.com", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isVerified",
                table: "Users");
        }
    }
}
