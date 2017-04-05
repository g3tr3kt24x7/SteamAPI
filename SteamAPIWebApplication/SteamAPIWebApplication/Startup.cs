using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SteamAPIWebApplication.Startup))]
namespace SteamAPIWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
