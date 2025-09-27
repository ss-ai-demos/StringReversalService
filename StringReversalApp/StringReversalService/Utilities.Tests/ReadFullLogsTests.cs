using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Utilities;

namespace Utilities.Tests;

[TestClass]
public sealed class ReadFullLogsTests
{
    private UtilitiesClass _utilitiesClass = null!;
    private string _testDirectory = null!;
    private string _tempLogFile = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _utilitiesClass = new UtilitiesClass();
        _testDirectory = Path.Combine(Path.GetTempPath(), "UtilitiesTests", Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testDirectory);
        _tempLogFile = Path.Combine(_testDirectory, "test.log");
    }

    [TestCleanup]
    public void TestCleanup()
    {
        try
        {
            if (Directory.Exists(_testDirectory))
            {
                // Ensure all file handles are closed by forcing garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
                
                // Try to delete files first
                var files = Directory.GetFiles(_testDirectory);
                foreach (var file in files)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException)
                    {
                        // File might be in use, skip it
                    }
                }
                
                Directory.Delete(_testDirectory, true);
            }
        }
        catch (Exception)
        {
            // Ignore cleanup errors in tests
        }
    }

    [TestMethod]
    public void ReadFullLogs_WithValidFileContainingText_ReturnsFileContent()
    {
        // Arrange
        string expectedContent = "This is a test log file.\nLine 2 of the log.\nLine 3 with special characters: @#$%^&*()";
        File.WriteAllText(_tempLogFile, expectedContent);

        // Act
        string result = _utilitiesClass.ReadFullLogs(_tempLogFile);

        // Assert
        Assert.AreEqual(expectedContent, result);
    }

    [TestMethod]
    public void ReadFullLogs_WithEmptyFile_ReturnsEmptyString()
    {
        // Arrange
        File.WriteAllText(_tempLogFile, string.Empty);

        // Act
        string result = _utilitiesClass.ReadFullLogs(_tempLogFile);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void ReadFullLogs_WithNullFilePath_ReturnsLogFileNotFoundMessage()
    {
        // Act
        string result = _utilitiesClass.ReadFullLogs(null!);

        // Assert
        Assert.AreEqual("Log file not found.", result);
    }

    [TestMethod]
    public void ReadFullLogs_WithEmptyStringFilePath_ReturnsLogFileNotFoundMessage()
    {
        // Act
        string result = _utilitiesClass.ReadFullLogs(string.Empty);

        // Assert
        Assert.AreEqual("Log file not found.", result);
    }

    [TestMethod]
    public void ReadFullLogs_WithWhitespaceFilePath_ReturnsLogFileNotFoundMessage()
    {
        // Act
        string result = _utilitiesClass.ReadFullLogs("   ");

        // Assert
        Assert.AreEqual("Log file not found.", result);
    }

    [TestMethod]
    public void ReadFullLogs_WithNonExistentFile_ReturnsLogFileNotFoundMessage()
    {
        // Arrange
        string nonExistentFile = Path.Combine(_testDirectory, "nonexistent.log");

        // Act
        string result = _utilitiesClass.ReadFullLogs(nonExistentFile);

        // Assert
        Assert.AreEqual("Log file not found.", result);
    }

    [TestMethod]
    public void ReadFullLogs_WithInvalidPath_ReturnsLogFileNotFoundMessage()
    {
        // Arrange
        string invalidPath = "C:\\InvalidPath\\DoesNotExist\\test.log";

        // Act
        string result = _utilitiesClass.ReadFullLogs(invalidPath);

        // Assert
        Assert.AreEqual("Log file not found.", result);
    }

    [TestMethod]
    public void ReadFullLogs_WithLargeFile_ReturnsFullContent()
    {
        // Arrange
        var contentBuilder = new System.Text.StringBuilder();
        for (int i = 1; i <= 1000; i++)
        {
            contentBuilder.AppendLine($"Log entry {i}: This is a test log entry with some content.");
        }
        string expectedContent = contentBuilder.ToString();
        File.WriteAllText(_tempLogFile, expectedContent);

        // Act
        string result = _utilitiesClass.ReadFullLogs(_tempLogFile);

        // Assert
        Assert.AreEqual(expectedContent, result);
    }

    [TestMethod]
    public void ReadFullLogs_WithSpecialCharactersInContent_ReturnsContentWithSpecialCharacters()
    {
        // Arrange
        string expectedContent = "Special chars: åäöñüß€£¥¢∞§¶•ªº°¿¡™£¢∞§¶\nUnicode: 你好世界\nEmoji: 😀😎🚀";
        File.WriteAllText(_tempLogFile, expectedContent);

        // Act
        string result = _utilitiesClass.ReadFullLogs(_tempLogFile);

        // Assert
        Assert.AreEqual(expectedContent, result);
    }

    [TestMethod]
    public void ReadFullLogs_WithJsonContent_ReturnsJsonString()
    {
        // Arrange
        string expectedContent = @"{
    ""timestamp"": ""2025-09-26T10:30:00Z"",
    ""level"": ""ERROR"",
    ""message"": ""Application failed to start"",
    ""exception"": ""System.Exception: Test exception""
}";
        File.WriteAllText(_tempLogFile, expectedContent);

        // Act
        string result = _utilitiesClass.ReadFullLogs(_tempLogFile);

        // Assert
        Assert.AreEqual(expectedContent, result);
    }

    [TestMethod]
    public void ReadFullLogs_WithSingleLineFile_ReturnsSingleLine()
    {
        // Arrange
        string expectedContent = "Single line log entry without newline";
        File.WriteAllText(_tempLogFile, expectedContent);

        // Act
        string result = _utilitiesClass.ReadFullLogs(_tempLogFile);

        // Assert
        Assert.AreEqual(expectedContent, result);
    }
}
