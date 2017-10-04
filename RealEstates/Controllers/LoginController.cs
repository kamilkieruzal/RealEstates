using RealEstates.Core.Contract;
using RealEstates.Core.Utils;
using RealEstates.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace RealEstates.Controllers
{
	public class LoginController : Controller
	{
		private IUserRepository userService;

		public LoginController(IUserRepository userService)
		{
			this.userService = userService;
		}

		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(UserLoginViewModel user)
		{
			var dbUser = userService.GetUser(user.Email);
			if (dbUser != null)
			{
				var md5Password = MD5Helper.CalculateMD5Hash(user.Password);
				if (dbUser.Password == md5Password)
				{
					FormsAuthentication.SetAuthCookie(dbUser.Email, false);

					TempData["message"] = "Zalogowano pomyślnie!";
					return Redirect(Url.Action("Index", "Default"));
				}
			}
			ViewBag.Communicate = "Błędne dane logowania!";
			return View();
		}

		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			ViewBag.Communicate = "Wylogowano pomyślnie!";
			return RedirectToAction("Index", "Default");
		}
	}
}