using System.ComponentModel.DataAnnotations;

namespace FirstApplication.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[StringLength(255)]
		public string Name { get; set; }
		[StringLength(10)]
		[Display(Name = "Date of Birth")]
		public string? Birthdate { get; set; }
		public bool IsSubcribedToNewsletter { get; set; }
		public MembershipType MembershipType { get; set; }
		public byte MemberShipTypeId { get; set; }
	}
}
