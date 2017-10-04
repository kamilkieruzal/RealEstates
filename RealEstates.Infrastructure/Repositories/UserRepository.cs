using RealEstates.Core.Entities;
using RealEstates.Core.Contract;
using System.Linq;

namespace RealEstates.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private RealEstatesContext realEstatesContext;

		public UserRepository(RealEstatesContext realEstatesContext)
		{
			this.realEstatesContext = realEstatesContext;
		}

		public void AddUser(User user)
		{
			realEstatesContext.Users.Add(user);
			realEstatesContext.SaveChanges();
		}

		public User GetUser(string email)
		{
			return realEstatesContext.Users
				.SingleOrDefault(u => u.Email == email);
		}
	}
}