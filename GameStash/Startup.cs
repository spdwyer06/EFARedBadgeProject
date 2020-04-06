using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameStash.Startup))]
namespace GameStash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
