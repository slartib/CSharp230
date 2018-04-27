using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomePageHW2.Startup))]
namespace HomePageHW2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
