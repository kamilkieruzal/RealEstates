using System.Web.Mvc;

namespace RealEstates.Controllers
{
	public class DefaultController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}