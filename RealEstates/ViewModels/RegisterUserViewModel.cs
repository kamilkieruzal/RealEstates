using RealEstates.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace RealEstates.ViewModels
{
	public class RegisterUserViewModel
	{
		[Display(Name = "Email")]
		[Required(ErrorMessage = "Pole Email jest wymagane")]
		[Remote("DoesUserNameExist", "Register", HttpMethod = "POST", ErrorMessage = "Użytkownik o takim adresie Email już istnieje!")]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
							@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
							@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
							ErrorMessage = "Format Email jest nieprawidłowy")]
		public string Email { get; set; }

		[Display(Name = "Numer telefonu")]
		[Required(ErrorMessage = "Numer telefonu jest wymagany")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Hasło")]
		[Required(ErrorMessage = "Hasło jest wymagane")]
		[StringLength(255, ErrorMessage = "Hasło musi mieć przynajmniej 5 znaków", MinimumLength = 5)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Potwierdź hasło")]
		[Required(ErrorMessage = "Potwierdzenie hasła jest wymagane")]
		[StringLength(255, ErrorMessage = "Hasło musi mieć przynajmniej 5 znaków", MinimumLength = 5)]
		[DataType(DataType.Password)]
		[System.ComponentModel.DataAnnotations.Compare("Password")]
		public string PasswordConfirmation { get; set; }

		[Display(Name = "Typ użytkownika")]
		[Required(ErrorMessage = "Typ użytkownika jest wymagany")]
		public UserType Type { get; set; }

		public ICollection<Offer> Offers { get; set; }

		[NotMapped]
		public IEnumerable<SelectListItem> ActionsList
		{
			get
			{
				return new List<SelectListItem>
				{
						new SelectListItem() {Text = "Kupuję", Value="1"},
						new SelectListItem() {Text = "Sprzedaję", Value="2"},
				};
			}
		}

		public bool IsValid()
		{
			return true;
		}
	}
}