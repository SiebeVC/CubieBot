using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website_Met_Auth.Startup))]
namespace Website_Met_Auth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
