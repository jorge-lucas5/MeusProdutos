using System.Data.Entity.Migrations;
namespace Estudos.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

    }
}
