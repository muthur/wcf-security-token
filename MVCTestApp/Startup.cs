using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTestApp.Startup))]
namespace MVCTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
