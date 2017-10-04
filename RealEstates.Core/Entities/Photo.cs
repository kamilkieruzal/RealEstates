using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstates.Core.Entities
{
	public class Photo : EntityBase<int>
	{
		public byte[] PhotoData { get; set; }
		public int OfferId { get; set; }

		[ForeignKey("OfferId")]
		public Offer Offer { get; set; }
	}
}