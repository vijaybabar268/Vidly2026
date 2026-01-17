using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly2026.Startup))]
namespace Vidly2026
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
