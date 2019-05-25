using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FreeExp.Startup))]
namespace FreeExp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
