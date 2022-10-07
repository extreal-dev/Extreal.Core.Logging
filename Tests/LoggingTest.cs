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
        LoggerManager.SetLogLevel(LogLevel.Debug);
        var logger = LoggerManager.Create(LOG_CATEGORY);
        var exception = new Exception();

        // Test to print debug
        var message = "Debug";
        logger.LogDebug(message);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{LOG_CATEGORY}] {message}");
        logger.LogDebug(message, exception);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{LOG_CATEGORY}] {message}\n----------\n{exception}");

        // Test to print info
        message = "Info";
        logger.LogInfo(message);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}");
        logger.LogInfo(message, exception);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}\n----------\n{exception}");


        // Test to print warn
        message = "Warn";
        logger.LogWarn(message);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
        logger.LogWarn(message, exception);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{exception}");


        // Test to print error
        message = "Error";
        logger.LogError(message);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
        logger.LogError(message, exception);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{exception}");
    }

    /// <summary>
    /// Test where LogLevel is Info
    /// </summary>
    [Test]
    public void LogMoreThanInfoLevel()
    {
        LoggerManager.SetLogLevel(LogLevel.Info);
        var logger = LoggerManager.Create(LOG_CATEGORY);
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
        LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}");
        logger.LogInfo(message, exception);
        LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}\n----------\n{exception}");


        // Test to print warn
        message = "Warn";
        logger.LogWarn(message);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
        logger.LogWarn(message, exception);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{exception}");


        // Test to print error
        message = "Error";
        logger.LogError(message);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
        logger.LogError(message, exception);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{exception}");
    }

    /// <summary>
    /// Test where LogLevel is Warn
    /// </summary>
    [Test]
    public void LogMoreThanWarnLevel()
    {
        LoggerManager.SetLogLevel(LogLevel.Warn);
        var logger = LoggerManager.Create(LOG_CATEGORY);
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
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
        logger.LogWarn(message, exception);
        LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{exception}");


        // Test to print error
        message = "Error";
        logger.LogError(message);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
        logger.LogError(message, exception);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{exception}");
    }

    /// <summary>
    /// Test where LogLevel is Error
    /// </summary>
    [Test]
    public void LogMoreThanErrorLevel()
    {
        LoggerManager.SetLogLevel(LogLevel.Error);
        var logger = LoggerManager.Create(LOG_CATEGORY);
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
        LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
        logger.LogError(message, exception);
        LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{exception}");
    }

    /// <summary>
    /// Test if 10,000 log outputs are executed within 5,000 milliseconds
    /// </summary>
    [Test]
    public void Log10kTimesWithin5000MilliSec()
    {
        LoggerManager.SetLogLevel(LogLevel.Debug);
        var logger = LoggerManager.Create(LOG_CATEGORY);

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

        // Assert execution time within 5000 milliseconds
        Assert.Less(timer.ElapsedMilliseconds, 5000);
    }

    private void OnLogMessageReceived(string logText, string stackTrace, LogType logType)
    {
        _logText = logText;
    }
}
