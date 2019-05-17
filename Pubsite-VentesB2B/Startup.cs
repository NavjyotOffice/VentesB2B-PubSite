using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pubsite_VentesB2B.Startup))]
namespace Pubsite_VentesB2B
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
