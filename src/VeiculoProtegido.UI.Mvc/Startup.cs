using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VeiculoProtegido.UI.Mvc.Startup))]
namespace VeiculoProtegido.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
