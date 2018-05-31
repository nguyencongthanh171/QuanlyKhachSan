using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyKSOmni.Startup))]
namespace QuanLyKSOmni
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
