using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Runtime.Remoting.Contexts;

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
