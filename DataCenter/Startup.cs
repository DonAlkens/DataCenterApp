using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataCenter.Startup))]
namespace DataCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
