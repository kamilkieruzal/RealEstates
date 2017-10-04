using Autofac;
using Autofac.Integration.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RealEstates
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			ConfigureContainer();
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		private void ConfigureContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}
