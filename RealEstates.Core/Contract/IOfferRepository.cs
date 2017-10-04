using RealEstates.Core.Entities;
using System.Collections.Generic;

namespace RealEstates.Core.Contract
{
	public interface IOfferRepository
	{
		IList<Offer> GetFilteredOffers(OfferFilter filter);
		Offer GetOffer(int offerId);
		void SaveOrUpdateOffer(Offer offer);
		IList<Offer> GetAllOffers();
		void AddOffer(Offer offer);
		IList<Offer> GetUserOffers(int userId);
		void DeleteOffer(int id);
	}
}
