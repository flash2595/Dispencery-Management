using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DispenceryManagement.Startup))]
namespace DispenceryManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}