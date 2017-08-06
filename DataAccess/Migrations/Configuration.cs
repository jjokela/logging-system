namespace DataAccess.Migrations
{
    using Entities;
    using EntityFramework.BulkExtensions;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.LogMessgeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Ef6WithMigrations.Models.LogMessgeContext";
        }

        protected override void Seed(DataContext.LogMessgeContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.BulkInsertOrUpdate(SeedData.GetSeedData(), InsertOptions.OutputIdentity);
        }
    }
}
