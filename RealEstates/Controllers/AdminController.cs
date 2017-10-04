using RealEstates.Core.Contract;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
	public class AdminController : Controller
	{
		private IOfferRepository offerService;
		private IUserRepository userService;

		public AdminController(
			IUserRepository userService,
			IOfferRepository offerService)
		{
			this.userService = userService;
			this.offerService = offerService;
		}

		public ActionResult Index()
		{
			return View();
		}
	}
}