using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WinstonAdmin.Startup))]
namespace WinstonAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
