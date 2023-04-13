using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApplication.Migrations
{
  /// <inheritdoc />
  public partial class PopulateMembershipTypes : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      //Insert all MembershipTypes
      migrationBuilder.Sql("INSERT INTO MembershipType (Id, SingUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
      migrationBuilder.Sql("INSERT INTO MembershipType (Id, SingUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
      migrationBuilder.Sql("INSERT INTO MembershipType (Id, SingUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
      migrationBuilder.Sql("INSERT INTO MembershipType (Id, SingUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
