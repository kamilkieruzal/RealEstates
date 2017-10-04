using Autofac;
using AutoMapper;
using RealEstates.MapperProfiles;

namespace RealEstates.Modules
{
	public class AutoMapperModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c => new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new MapperProfile());
			})).AsSelf().SingleInstance();

			builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
				.As<IMapper>()
				.InstancePerLifetimeScope();

			base.Load(builder);
		}
	}
}