using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApplication.Migrations
{
  /// <inheritdoc />
  public partial class AddIsSubscribedToNl : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<string>(
          name: "Name",
          table: "Movie",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "nvarchar(max)",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "Name",
          table: "Customer",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "nvarchar(max)",
          oldNullable: true);

      migrationBuilder.AddColumn<bool>(
          name: "IsSubcribedToNewsletter",
          table: "Customer",
          type: "bit",
          nullable: false,
          defaultValue: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "IsSubcribedToNewsletter",
          table: "Customer");

      migrationBuilder.AlterColumn<string>(
          name: "Name",
          table: "Movie",
          type: "nvarchar(max)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(max)");

      migrationBuilder.AlterColumn<string>(
          name: "Name",
          table: "Customer",
          type: "nvarchar(max)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(max)");
    }
  }
}
