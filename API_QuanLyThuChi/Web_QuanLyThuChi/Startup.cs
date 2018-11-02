using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_QuanLyThuChi.Startup))]
namespace Web_QuanLyThuChi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
