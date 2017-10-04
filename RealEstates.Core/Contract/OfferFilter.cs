namespace RealEstates.Core.Contract
{
	public class OfferFilter
	{
		public int? MinNumberOfRooms { get; set; }
		public int? MaxNumberOfRooms { get; set; }
		public int? MinArea { get; set; }
		public int? MaxArea { get; set; }
		public decimal? MinPrice { get; set; }
		public decimal? MaxPrice { get; set; }
		public bool IsBalcony { get; set; }
		public short? Level { get; set; }
	}
}