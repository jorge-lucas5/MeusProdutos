using System.Data.Entity.Migrations;
namespace Estudos.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

    }
}
