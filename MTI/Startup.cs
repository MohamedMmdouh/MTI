using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MTI.Startup))]
namespace MTI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
