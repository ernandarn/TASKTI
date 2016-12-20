using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TASKTI.Startup))]
namespace TASKTI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
