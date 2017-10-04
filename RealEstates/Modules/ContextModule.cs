using Autofac;
using RealEstates.Infrastructure;

namespace RealEstates.Modules
{
	public class ContextModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(RealEstatesContext).Assembly)
				.InstancePerRequest();

			base.Load(builder);
		}
	}
}