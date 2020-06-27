using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nuevo_proyecto.Startup))]
namespace Nuevo_proyecto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
