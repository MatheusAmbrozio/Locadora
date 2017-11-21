using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocadoraS2IT.Web.Startup))]
namespace LocadoraS2IT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
