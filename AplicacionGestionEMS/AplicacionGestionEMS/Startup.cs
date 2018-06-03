using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplicacionGestionEMS.Startup))]
namespace AplicacionGestionEMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
