using System.ComponentModel.DataAnnotations;

namespace FirstApplication.Models
{
  public class MembershipType
  {
    public byte Id { get; set; }
    [StringLength(255)]
    public string Name { get; set; }
    public short SingUpFee { get; set; }
    public byte DurationInMonths { get; set; }
    public byte DiscountRate { get; set; }
  }
}
