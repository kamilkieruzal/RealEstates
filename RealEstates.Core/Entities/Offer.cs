using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstates.Core.Entities
{
	public class Offer : EntityBase<int>
	{
		public string Location { get; set; }
		public int NumberOfRooms { get; set; }
		public int Area { get; set; }
		public int Level { get; set; }
		public bool IsBalcony { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public int UserId { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }

		public virtual ICollection<Photo> Photos { get; set; }
	}
}