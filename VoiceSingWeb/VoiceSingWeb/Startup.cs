using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoiceSingWeb.Startup))]
namespace VoiceSingWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
