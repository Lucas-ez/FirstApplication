using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApplication.Migrations
{
  /// <inheritdoc />
  public partial class populateMembershipType : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      //Insert all MembershipTypes
      migrationBuilder.Sql("INSERT INTO MembershipType (Id, SingUpFee, DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0, 'Pay as You Go')");
      migrationBuilder.Sql("INSERT INTO MembershipType (Id, SingUpFee, DurationInMonths, DiscountRate, Name) VALUES (2, 30, 1, 10, 'Monthly')");
      migrationBuilder.Sql("INSERT INTO MembershipType (Id, SingUpFee, DurationInMonths, DiscountRate, Name) VALUES (3, 90, 3, 15, 'Quarterly')");
      migrationBuilder.Sql("INSERT INTO MembershipType (Id, SingUpFee, DurationInMonths, DiscountRate, Name) VALUES (4, 300, 12, 20, 'Annual')");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
