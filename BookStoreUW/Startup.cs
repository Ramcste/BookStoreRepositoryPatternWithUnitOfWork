using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreUW.Startup))]
namespace BookStoreUW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
