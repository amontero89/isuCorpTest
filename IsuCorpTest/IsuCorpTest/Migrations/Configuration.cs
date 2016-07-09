namespace IsuCorpTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IsuCorpTest.Entities.IsuCorpModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IsuCorpTest.Entities.IsuCorpModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.ContactTypes.AddOrUpdate(
              p => p.ContacTypeName,
              new Entities.ContactType { ContacTypeName = "Contact Type 1" },
              new Entities.ContactType { ContacTypeName = "Contact Type 2" },
              new Entities.ContactType { ContacTypeName = "Contact Type 3" }
            );
        }
    }
}
