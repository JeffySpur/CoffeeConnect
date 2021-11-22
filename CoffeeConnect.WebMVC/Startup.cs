using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeeConnect.WebMVC.Startup))]
namespace CoffeeConnect.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
