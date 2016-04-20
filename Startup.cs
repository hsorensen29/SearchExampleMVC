using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchExampleMVC.Startup))]
namespace SearchExampleMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
