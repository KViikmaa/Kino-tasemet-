using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kino_tasemetöö.Startup))]
namespace Kino_tasemetöö
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
