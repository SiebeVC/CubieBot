using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website2CubieBot.Startup))]
namespace Website2CubieBot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
