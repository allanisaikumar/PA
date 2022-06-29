using PA.Log.Manager.Models;

namespace PA.Log.Manager
{
    public interface ILog
    {
        List<LogItem> GetLogs(string? id = null);
    }
}
