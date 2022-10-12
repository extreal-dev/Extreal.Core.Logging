using System;
using System.Diagnostics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Extreal.Core.Logging;

public class LoggingTest
{
    private const string LOG_CATEGORY = "Test";
    private string _logText;

    // A Test behaves as an ordinary method
    [SetUp]
    public void Initialize()
    {
        Application.logMessageReceived += OnLogMessageReceived;
        _logText = "";
    }

    [TearDown]
    public void Dispose()
    {
        Application.logMessageReceived -= OnLogMessageReceived;
    }

    /// <summary>
    /// Test where LogLevel is Debug
    /// </summary>
    [Test]
    public void LogMoreThanDebugLevel()
    {
        LoggingManager.SetLogLevel(LogLevel.DEBUG);
        var logger = LoggingManager.GetLogger(LOG_CATEGORY);
        var exception = new Exception();

        // Test to print debug
        var message = "Debug";
        logger.LogDebug(message);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.DEBUG}:{LOG_CATEGORY}] {message}");
        logger.LogDebug(message, exception);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.DEBUG}:{LOG_CATEGORY}] {message}\n----------\n{exception}");

        // Test to print info
        message = "Info";
        logger.LogInfo(message);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.INFO}:{LOG_CATEGORY}] {message}");
        logger.LogInfo(message, exception);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.INFO}:{LOG_CATEGORY}] {message}\n----------\n{exception}");

        // Test to print warn
        message = "Warn";
        logger.LogWarn(message);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}");
        logger.LogWarn(message, exception);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}\n----------\n{exception}");

        // Test to print error
        message = "Error";
        logger.LogError(message);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}");
        logger.LogError(message, exception);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}\n----------\n{exception}");
    }

    /// <summary>
    /// Test where LogLevel is Info
    /// </summary>
    [Test]
    public void LogMoreThanInfoLevel()
    {
        LoggingManager.SetLogLevel(LogLevel.INFO);
        var logger = LoggingManager.GetLogger(LOG_CATEGORY);
        var exception = new Exception();

        // Test to print debug
        var message = "Debug";
        logger.LogDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";
        logger.LogDebug(message, exception);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to print info
        message = "Info";
        logger.LogInfo(message);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.INFO}:{LOG_CATEGORY}] {message}");
        logger.LogInfo(message, exception);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.INFO}:{LOG_CATEGORY}] {message}\n----------\n{exception}");

        // Test to print warn
        message = "Warn";
        logger.LogWarn(message);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}");
        logger.LogWarn(message, exception);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}\n----------\n{exception}");

        // Test to print error
        message = "Error";
        logger.LogError(message);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}");
        logger.LogError(message, exception);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}\n----------\n{exception}");
    }

    /// <summary>
    /// Test where LogLevel is Warn
    /// </summary>
    [Test]
    public void LogMoreThanWarnLevel()
    {
        LoggingManager.SetLogLevel(LogLevel.WARN);
        var logger = LoggingManager.GetLogger(LOG_CATEGORY);
        var exception = new Exception();

        // Test to print debug
        var message = "Debug";
        logger.LogDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";
        logger.LogDebug(message, exception);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to print info
        message = "Info";
        logger.LogInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";
        logger.LogInfo(message, exception);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to print warn
        message = "Warn";
        logger.LogWarn(message);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}");
        logger.LogWarn(message, exception);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}\n----------\n{exception}");

        // Test to print error
        message = "Error";
        logger.LogError(message);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}");
        logger.LogError(message, exception);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}\n----------\n{exception}");
    }

    /// <summary>
    /// Test where LogLevel is Error
    /// </summary>
    [Test]
    public void LogMoreThanErrorLevel()
    {
        LoggingManager.SetLogLevel(LogLevel.ERROR);
        var logger = LoggingManager.GetLogger(LOG_CATEGORY);
        var exception = new Exception();

        // Test to print debug
        var message = "Debug";
        logger.LogDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";
        logger.LogDebug(message, exception);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to print info
        message = "Info";
        logger.LogInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";
        logger.LogInfo(message, exception);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to print warn
        message = "Warn";
        logger.LogWarn(message);
        Assert.IsEmpty(_logText);
        _logText = "";
        logger.LogWarn(message, exception);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to print error
        message = "Error";
        logger.LogError(message);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}");
        logger.LogError(message, exception);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}\n----------\n{exception}");
    }

    /// <summary>
    /// Test if 10,000 log outputs are executed within 3,000 milliseconds
    /// </summary>
    [Test]
    public void Log10kTimesWithin3000MilliSec()
    {
        LoggingManager.SetLogLevel(LogLevel.DEBUG);
        var logger = LoggingManager.GetLogger(LOG_CATEGORY);

        // Start timer
        var timer = new Stopwatch();
        timer.Start();

        // Log 10,000 times
        for (var i = 0; i < 10_000; i++)
        {
            logger.LogDebug("Test");
        }

        // Stop timer
        timer.Stop();

        // Assert execution time within 3,000 milliseconds
        Assert.Less(timer.ElapsedMilliseconds, 3_000);
    }

    private void OnLogMessageReceived(string logText, string stackTrace, LogType logType)
    {
        _logText = logText;
    }
}
