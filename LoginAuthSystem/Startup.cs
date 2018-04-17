using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginAuthSystem.Startup))]
namespace LoginAuthSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
