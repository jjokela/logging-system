using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Migrations
{
    public class SeedData
    {
        public static List<LogMessage> GetSeedData()
        {
            var date = DateTime.Parse("2017-08-06 7:34:42Z");
            var messages = new List<LogMessage> {

                new LogMessage
                {
                    MessageType = MessageType.Error,
                    Title = "Something went wrong!",
                    Message = "Something went wrong when trying to initialize stuff or something.",
                    Created = date,
                    IsRead = false
                },
                new LogMessage
                {
                    MessageType = MessageType.Success,
                    Title = "Managed to run stuff!",
                    Message = "Everything is smooth & peachy",
                    Created = date,
                    IsRead = false
                },
                new LogMessage
                {
                    MessageType = MessageType.Warning,
                    Title = "Uh oh, something might be wrong",
                    Message = "...but not neccessarily is. This is just a warning.",
                    Created = date,
                    IsRead = false
                },
                new LogMessage
                {
                    MessageType = MessageType.Information,
                    Title = "This is just some general notification",
                    Message = "Might be worth logging it, tho",
                    Created = date,
                    IsRead = false
                }
            };

            return messages;
        }
    }
}
