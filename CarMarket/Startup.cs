using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarMarket.Startup))]
namespace CarMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
