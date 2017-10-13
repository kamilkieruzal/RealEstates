using System.Collections.Generic;
using System.Web;

namespace RealEstates.ViewModels
{
	public class AddOfferViewModel
	{
		public string Location { get; set; }
		public int NumberOfRooms { get; set; }
		public int Area { get; set; }
		public int Level { get; set; }
		public bool IsBalcony { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public ICollection<HttpPostedFileBase> Photos { get; set; }
	}
}