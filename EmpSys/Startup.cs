using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpSys.Startup))]
namespace EmpSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
