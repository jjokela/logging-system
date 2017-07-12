using Entities;
using System.Linq;

namespace Logger
{
    public interface ILogger
    {
        void WriteLogMessage(LogMessage message);

        void UpdateLogMessage(int id, LogMessage message);

        IQueryable<LogMessage> GetLogMessages();
    }
}
