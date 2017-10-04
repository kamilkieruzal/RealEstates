using System.Collections.Generic;

namespace RealEstates.Core.Entities
{
	public class User : EntityBase<int>
	{
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public UserType Type { get; set; }
		public ICollection<Offer> Offers { get; set; }
	}

	public enum UserType
	{
		Admin,
		Buyer,
		Seller
	}
}