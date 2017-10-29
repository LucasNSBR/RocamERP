namespace RocamERP.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RocamDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RocamDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var mg = new Domain.Models.Estado()
            {
                Nome = "Minas Gerais",
            };

            var sp = new Domain.Models.Estado()
            {
                Nome = "São Paulo",
            };

            var rj = new Domain.Models.Estado()
            {
                Nome = "Rio de Janeiro",
            };
        }
    }
}
