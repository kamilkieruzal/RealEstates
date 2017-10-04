using RealEstates.Core.Contract;
using RealEstates.Core.Entities;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
	public class MyOfferController : Controller
	{
		private IUserRepository userRepository;
		private IOfferRepository offerRepository;

		public MyOfferController(
			IUserRepository userRepository,
			IOfferRepository offerRepository)
		{
			this.userRepository = userRepository;
			this.offerRepository = offerRepository;
		}

		public ActionResult Index()
		{
			return View();
		}

		[Authorize]
		public ActionResult MyOffers()
		{
			var email = HttpContext.User.Identity.Name;
			var user = userRepository.GetUser(email);
			var offers = offerRepository.GetUserOffers(user.Id);
			
			return View(offers);
		}

		[HttpGet]
		[Authorize]
		public ActionResult AddOffer()
		{
			return View();
		}

		[HttpPost]
		[Authorize]
		public ActionResult AddOffer(Offer offer)
		{
			var email = HttpContext.User.Identity.Name;
			var user = userRepository.GetUser(email);
			offer.UserId = user.Id;
			offerRepository.AddOffer(offer);

			var offers = offerRepository.GetUserOffers(user.Id);

			return Redirect(Url.Action("MyOffers", "MyOffer"));
		}

		[HttpPost]
		[Authorize]
		public ActionResult Delete(int id)
		{
			var email = HttpContext.User.Identity.Name;
			var user = userRepository.GetUser(email);
			offerRepository.DeleteOffer(id);

			var offers = offerRepository.GetUserOffers(user.Id);

			return Redirect(Url.Action("MyOffers", "MyOffer"));
		}

		[HttpPost]
		[Authorize]
		public ActionResult Edit(Offer offer)
		{
			return Redirect(Url.Action("MyOffers", "MyOffer"));
		}
	}
}