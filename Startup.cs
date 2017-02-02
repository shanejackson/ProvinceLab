using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab03Canada.Startup))]
namespace Lab03Canada
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
