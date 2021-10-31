using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoClase.Startup))]
namespace ProyectoClase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
