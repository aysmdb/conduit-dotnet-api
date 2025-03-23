using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conduit_dotnet_api.Migrations
{
    /// <inheritdoc />
    public partial class articleuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "UserFavorite",
                columns: table => new
                {
                    FavoriteById = table.Column<int>(type: "int", nullable: false),
                    FavoritesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorite", x => new { x.FavoriteById, x.FavoritesId });
                    table.ForeignKey(
                        name: "FK_UserFavorite_Articles_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorite_Users_FavoriteById",
                        column: x => x.FavoriteById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorite_FavoritesId",
                table: "UserFavorite",
                column: "FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "UserFavorite");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
