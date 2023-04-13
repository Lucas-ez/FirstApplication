using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MemberShipTypeId",
                table: "Customer",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    SingUpFee = table.Column<short>(type: "smallint", nullable: false),
                    DurationInMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountRate = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_MemberShipTypeId",
                table: "Customer",
                column: "MemberShipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_MembershipType_MemberShipTypeId",
                table: "Customer",
                column: "MemberShipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_MembershipType_MemberShipTypeId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Customer_MemberShipTypeId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MemberShipTypeId",
                table: "Customer");
        }
    }
}
