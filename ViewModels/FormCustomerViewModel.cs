using FirstApplication.Models;

namespace FirstApplication.ViewModels
{
	public class FormCustomerViewModel
	{
		public IEnumerable<MembershipType> MembershipTypes { get; set; }
		public Customer Customer { get; set; }
	}
}
