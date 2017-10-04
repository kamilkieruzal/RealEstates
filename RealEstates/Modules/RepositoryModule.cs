using Autofac;
using RealEstates.Core.Contract;
using RealEstates.Infrastructure.Repositories;

namespace RealEstates.Modules
{
	public class RepositoryModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<UserRepository>()
				.As<IUserRepository>();

			builder.RegisterType<OfferRepository>()
				.As<IOfferRepository>();

			base.Load(builder);
		}
	}
}