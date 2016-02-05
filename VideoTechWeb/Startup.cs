using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoTech.Startup))]
namespace VideoTech
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
