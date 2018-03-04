using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CuelloUterino.Startup))]
namespace CuelloUterino
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
