using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_EF.Startup))]
namespace MVC_EF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
