using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZooRestaurant.Web.Startup))]
namespace ZooRestaurant.Web
{
    using System.Data.Entity.Migrations;
    using Data.Migrations;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);

            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
    }
}