using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlusSize.Startup))]
namespace PlusSize
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
