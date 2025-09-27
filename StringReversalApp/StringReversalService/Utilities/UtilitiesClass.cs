using System.IO;

namespace Utilities;

public class UtilitiesClass
{
    internal string ReadFullLogs(string logFilePath)
    {
        if (string.IsNullOrEmpty(logFilePath) || !File.Exists(logFilePath))
        {
            return "Log file not found.";
        }
        return File.ReadAllText(logFilePath);
    }
}
