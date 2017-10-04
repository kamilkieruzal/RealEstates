using RealEstates.Core.Entities;

namespace RealEstates.Core.Contract
{
	public interface IUserRepository
	{
		User GetUser(string email);
		void AddUser(User user);
	}
}