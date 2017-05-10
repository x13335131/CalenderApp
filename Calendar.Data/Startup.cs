using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Calendar.Data.Startup))]
namespace Calendar.Data
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
