using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PDS2_Store.Startup))]
namespace PDS2_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
