using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApplication.Migrations
{
  /// <inheritdoc />
  public partial class PopulateGenres : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<DateTime>(
          name: "AddedDate",
          table: "Movie",
          type: "datetime2",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

      migrationBuilder.AddColumn<byte>(
          name: "MovieGenreId",
          table: "Movie",
          type: "tinyint",
          nullable: false,
          defaultValue: (byte)0);

      migrationBuilder.AddColumn<DateTime>(
          name: "ReleaseDate",
          table: "Movie",
          type: "datetime2",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

      migrationBuilder.AddColumn<int>(
          name: "Stock",
          table: "Movie",
          type: "int",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.CreateTable(
          name: "MovieGenre",
          columns: table => new
          {
            Id = table.Column<byte>(type: "tinyint", nullable: false),
            Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_MovieGenre", x => x.Id);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Movie_MovieGenreId",
          table: "Movie",
          column: "MovieGenreId");

      migrationBuilder.AddForeignKey(
          name: "FK_Movie_MovieGenre_MovieGenreId",
          table: "Movie",
          column: "MovieGenreId",
          principalTable: "MovieGenre",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.Sql("INSERT INTO MovieGenre (Id, Name) VALUES (1, 'Comedy')");
      migrationBuilder.Sql("INSERT INTO MovieGenre (Id, Name) VALUES (2, 'Action')");
      migrationBuilder.Sql("INSERT INTO MovieGenre (Id, Name) VALUES (3, 'Family')");
      migrationBuilder.Sql("INSERT INTO MovieGenre (Id, Name) VALUES (4, 'Romance')");

    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Movie_MovieGenre_MovieGenreId",
          table: "Movie");

      migrationBuilder.DropTable(
          name: "MovieGenre");

      migrationBuilder.DropIndex(
          name: "IX_Movie_MovieGenreId",
          table: "Movie");

      migrationBuilder.DropColumn(
          name: "AddedDate",
          table: "Movie");

      migrationBuilder.DropColumn(
          name: "MovieGenreId",
          table: "Movie");

      migrationBuilder.DropColumn(
          name: "ReleaseDate",
          table: "Movie");

      migrationBuilder.DropColumn(
          name: "Stock",
          table: "Movie");
    }
  }
}
