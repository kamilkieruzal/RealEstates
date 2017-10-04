using RealEstates.Core.Contract;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace RealEstates.Controllers
{
	public class OfferController : Controller
	{
		private IUserRepository userService;
		private IOfferRepository offerService;

		public OfferController(
			IOfferRepository offerService,
			IUserRepository userService)
		{
			this.userService = userService;
			this.offerService = offerService;
		}

		public ActionResult Index()
		{
			return View();
		}

		[Authorize]
		public ActionResult AllOffers(OfferFilter filter = null)
		{
			var email = HttpContext.User.Identity.Name;
			var user = userService.GetUser(email);
			if (user != null)
			{
				if (filter == null)
					filter = new OfferFilter();
				var offers = offerService.GetFilteredOffers(filter);

				return View(offers);
			}
			return RedirectToAction("Index", "Default");
		}

		[Authorize]
		public ActionResult SendOfferMessage(int offerId)
		{
			var email = HttpContext.User.Identity.Name;
			var offer = offerService.GetOffer(offerId);
			var message = new Message();
			return View();
		}
	}
}