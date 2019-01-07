using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Corbin.Startup))]
namespace Corbin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
