namespace DataAccess.Migrations
{
    using Entities;
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

            context.LogMessages.AddOrUpdate(
                m => m.Title,
                new LogMessage {
                    MessageType = MessageType.Error,
                    Title = "Something went wrong!",
                    Message = "Something went wrong when trying to initialize stuff or something.",
                    Created = DateTime.Now,
                    IsRead = false
                },
                new LogMessage
                {
                    MessageType = MessageType.Success,
                    Title = "Managed to run stuff!",
                    Message = "Everything is smooth & peachy",
                    Created = DateTime.Now,
                    IsRead = false
                },
                new LogMessage
                {
                    MessageType = MessageType.Warning,
                    Title = "Uh oh, something might be wrong",
                    Message = "...but not neccessarily is. This is just a warning.",
                    Created = DateTime.Now,
                    IsRead = false
                },
                new LogMessage
                {
                    MessageType = MessageType.Information,
                    Title = "This is just some general notification",
                    Message = "Might be worth logging it, tho",
                    Created = DateTime.Now,
                    IsRead = false
                }

            );
        }
    }
}
