using Owin;
using System.Web.Http;

namespace AvaliacaoMeta.BackEnd.Api
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();

			WebApiConfig.Register(config);
			JsonConfig.Register(config);
			IdCConfig.Register(config);

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);

			//SwaggerConfig.Register(config);
		}
	}
}