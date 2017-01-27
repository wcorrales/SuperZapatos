using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperZapatosWeb.Startup))]
namespace SuperZapatosWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
