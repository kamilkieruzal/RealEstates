using RealEstates.Core.Entities;
using System.Data.Entity;

namespace RealEstates.Infrastructure
{
	public class RealEstatesContext : DbContext
	{
		public RealEstatesContext() : base("DBConnection")
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Photo> Photos { get; set; }
		public DbSet<Offer> Offers { get; set; }
		public DbSet<Message> Messages { get; set; }
	}
}