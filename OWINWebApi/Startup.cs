using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
[assembly: OwinStartup(typeof(OWINWebApi.Startup))]
namespace OWINWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(LoggerModule), "OwinLogger");
            app.Use(typeof(WebApiModule));
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "{controller}");
            app.UseWebApi(config);
        }
    }
}
