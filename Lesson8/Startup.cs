using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lesson8.Startup))]
namespace Lesson8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
