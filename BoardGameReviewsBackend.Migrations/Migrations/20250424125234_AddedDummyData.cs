using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoardGameReviewsBackend.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "weight",
                table: "Boardgames",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Boardgames",
                columns: new[] { "boardgameid", "Category", "Description", "Image", "ReleaseDate", "Title", "nrOfPlayers", "playTime", "weight" },
                values: new object[,]
                {
                    { 1, "Abstract", "Decorate a palace ceiling after creating your own pattern.", "/azul_duel.jpg", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Azul Duel", 2, 60, 2.2000000000000002 },
                    { 2, "Strategy", "Explore an island, discover artifacts, and defeat guardians.", "/lost_ruins_of_arnak.jpg", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lost Ruins of Arnak", 1, 120, 2.5 },
                    { 3, "Strategy", "Influence, intrigue, and combat in the universe of Dune.", "/dune_imperium.jpg", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dune Imperium", 1, 120, 3.0 },
                    { 4, "Abstract", "Sew a quilt, collect buttons, attract cats!", "/calico.jpg", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Calico", 4, 45, 1.8 },
                    { 5, "Cooperative", "Mutating diseases are spreading around the world - can your team save humanity?", "/pandemic_legacy.jpg", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pandemic Legacy", 2, 60, 3.5 },
                    { 6, "Cooperative", "Complete missions in space in this cooperative trick-taking game.", "/the_crew.jpg", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The Crew", 2, 30, 2.0 },
                    { 7, "Family", "In this competitive real estate market, there's only one possible outcome: Monopoly!", "/monopoly.jpg", new DateTime(1935, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Monopoly", 4, 90, 1.0 },
                    { 8, "Party", "Give your team clever one-word clues to help them spot their agents in the field.", "/codenames.jpg", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Codenames", 4, 30, 1.5 },
                    { 9, "Strategy", "Collect and trade resources to build up the island of Catan in this modern classic.", "/catan.jpg", new DateTime(1995, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Catan", 3, 90, 2.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Boardgames",
                keyColumn: "boardgameid",
                keyValue: 9);

            migrationBuilder.AlterColumn<int>(
                name: "weight",
                table: "Boardgames",
                type: "integer",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
