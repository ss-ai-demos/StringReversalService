using System.IO;

namespace Utilities;

public class UtilitiesClass
{
    // Method to calculate factorial of a number
    public long Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("Negative numbers do not have a factorial.");
        if (n == 0 || n == 1)
            return 1;
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    // Specify the path to your log file here
    string logFilePath = "path/to/your/logfile.txt";
    string logContent;

    public UtilitiesClass()
    {
        logContent = ReadFullLogs(logFilePath);
    }

    internal string ReadFullLogs(string logFilePath)
    {
        if (string.IsNullOrEmpty(logFilePath) || !File.Exists(logFilePath))
        {
            return "Log file not found.";
        }
        return File.ReadAllText(logFilePath);
    }
}
