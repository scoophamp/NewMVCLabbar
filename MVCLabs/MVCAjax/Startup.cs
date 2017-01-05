using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAjax.Startup))]
namespace MVCAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
