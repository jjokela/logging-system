using Entities;
using Microsoft.AspNet.SignalR;

namespace Logging.Web.Hubs
{
    public class LogHub : Hub
    {
        public static void PublishMessage(LogMessage message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
            context.Clients.All.publishMessage(message);
        }

        public static void UpdateMessage(LogMessage message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
            context.Clients.All.updateMessage(message);
        }
    }
}
