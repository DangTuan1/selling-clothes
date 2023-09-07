using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(selling_clothes_app.Startup))]
namespace selling_clothes_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
