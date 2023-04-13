using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthdateToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Birthdate",
                table: "Customer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Customer");
        }
    }
}
