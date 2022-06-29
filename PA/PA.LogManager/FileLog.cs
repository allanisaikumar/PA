using Newtonsoft.Json;
using PA.Log.Manager.Models;
using PA.Utils;

namespace PA.Log.Manager
{
    public class FileLog : ILog
    {
        private readonly string _logsFolderPath;

        public FileLog(ApplicationSettings applicationSettings)
        {
            _logsFolderPath = applicationSettings.FileLogsFolderPath;
        }

        public List<LogItem> GetLogs(string? id = null)
        {
            var logs = new List<LogItem>();
            var fileLines = FileUtil.ReadAllLinesOfAllFiles(_logsFolderPath);

            foreach (var item in fileLines)
            {
                var temp = item.Split("|");
                if (temp.Length > 1)
                {
                    var logItem = ParseLogItem(string.Join("|", temp.Skip(1)));

                    if (logItem != null && (id == null || id == logItem.ID))
                    {
                        logItem.Time = Convert.ToDateTime(temp[0]);
                        logs.Add(logItem);
                    }
                }
            }
            return logs;
        }


        private LogItem ParseLogItem(string str)
        {
            try
            {
                return JsonConvert.DeserializeObject<LogItem>(str);
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
}
