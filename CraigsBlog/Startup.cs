using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CraigsBlog.Startup))]
namespace CraigsBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
