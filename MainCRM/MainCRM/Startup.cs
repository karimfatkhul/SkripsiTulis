using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MainCRM.Startup))]
namespace MainCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
