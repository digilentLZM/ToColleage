using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DaChuang.Startup))]
namespace DaChuang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
