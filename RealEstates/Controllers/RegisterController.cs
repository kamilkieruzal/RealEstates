using AutoMapper;
using RealEstates.Core.Contract;
using RealEstates.Core.Entities;
using RealEstates.Core.Utils;
using RealEstates.Web.ViewModels;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IUserRepository userRepository;
		private readonly IMapper mapper;

		public RegisterController(
			IUserRepository userRepository,
			IMapper mapper)
		{
			this.userRepository = userRepository;
			this.mapper = mapper;
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterUserViewModel userViewModel)
		{
			var user = mapper.Map<User>(userViewModel);
			if (ModelState.IsValid)
			{
				if(userRepository.GetUser(user.Email) == null)
				{
					user.Password = MD5Helper.CalculateMD5Hash(user.Password);
					userRepository.AddUser(user);
				}
				return Redirect(Url.Action("Index", "Default"));
			}
			return View(userViewModel);
		}

		[HttpPost]
		public JsonResult DoesUserNameExist(string email)
		{
			if(userRepository.GetUser(email) != null)
				return Json(false);
			return Json(true);
		}
	}
}