using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Weat.UI.Startup))]
namespace Weat.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
