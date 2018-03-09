using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyApp.UI.Startup))]
namespace MyApp.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
