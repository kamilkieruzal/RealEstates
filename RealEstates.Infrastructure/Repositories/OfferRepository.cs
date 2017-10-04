using RealEstates.Core.Entities;
using RealEstates.Core.Contract;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Infrastructure.Repositories
{
	public class OfferRepository : IOfferRepository
	{
		private RealEstatesContext realEstatesContext;

		public OfferRepository(RealEstatesContext realEstatesContext)
		{
			this.realEstatesContext = realEstatesContext;
		}
		
		public void AddOffer(Offer offer)
		{
			realEstatesContext.Offers.Add(offer);
			realEstatesContext.SaveChanges();
		}
		
		public void DeleteOffer(int id)
		{
			var offer = realEstatesContext.Offers.Find(id);
			realEstatesContext.Offers.Remove(offer);

			realEstatesContext.SaveChanges();
		}

		public IList<Offer> GetFilteredOffers(OfferFilter filter)
		{
			return FilterOffers(realEstatesContext.Offers.AsQueryable(), filter);
		}

		public IList<Offer> GetUserOffers(int userId)
		{
			return realEstatesContext.Offers
				.Where(o => o.UserId == userId)
				.ToList();
		}

		public IList<Offer> GetAllOffers()
		{
			return realEstatesContext.Offers.OrderBy(x => x.UserId)
				.ToList();
		}

		public Offer GetOffer(int offerId)
		{
			return realEstatesContext.Offers.Find(offerId);
		}

		public void SaveOrUpdateOffer(Offer offer)
		{
			var offer2 = realEstatesContext.Offers.Find(offer.Id);
			if (offer2 == null)
				realEstatesContext.Offers.Add(offer);
			else
				realEstatesContext.Entry(offer2).CurrentValues.SetValues(offer);

			realEstatesContext.SaveChanges();
		}

		private IList<Offer> FilterOffers(IQueryable<Offer> offers, OfferFilter filter)
		{
			if (filter.IsBalcony == true)
				offers = offers.Where(o => o.IsBalcony == true);

			if (filter.MinPrice.HasValue)
				offers = offers.Where(o => o.Price >= filter.MinPrice.Value);
			if (filter.MaxPrice.HasValue)
				offers = offers.Where(o => o.Price <= filter.MaxPrice.Value);

			if (filter.MinArea.HasValue)
				offers = offers.Where(o => o.Area >= filter.MinArea.Value);
			if (filter.MaxArea.HasValue)
				offers = offers.Where(o => o.Area <= filter.MaxArea.Value);

			if (filter.MinNumberOfRooms.HasValue)
				offers = offers.Where(o => o.NumberOfRooms >= filter.MinNumberOfRooms.Value);
			if (filter.MaxNumberOfRooms.HasValue)
				offers = offers.Where(o => o.NumberOfRooms <= filter.MaxNumberOfRooms.Value);

			if (filter.Level.HasValue)
				offers = offers.Where(o => o.Level == filter.Level.Value);

			if (filter.Level.HasValue)
				offers = offers.Where(o => o.Level == filter.Level.Value);

			return offers.ToList();
		}
	}
}
