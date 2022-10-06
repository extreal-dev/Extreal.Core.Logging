using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Extreal.Core.Logging;

public class LoggingTest
{
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
    /// Test using only debug log
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithDebug()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Debug,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.AreEqual($"[{LogLevel.Debug}] {message}", _logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.IsEmpty(_logText);
        _logText = "";
    }

    /// <summary>
    /// Test using only info log
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithInfo()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Info,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.AreEqual($"[{LogLevel.Info}] {message}", _logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.IsEmpty(_logText);
        _logText = "";
    }

    /// <summary>
    /// Test using only warn log
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithWarn()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Warn,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.AreEqual($"[{LogLevel.Warn}] {message}", _logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.IsEmpty(_logText);
        _logText = "";
    }

    /// <summary>
    /// Test using only error log
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithError()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Error,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.AreEqual($"[{LogLevel.Error}] {message}", _logText);
        _logText = "";
    }

    /// <summary>
    /// Test using debug and info logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithDebugInfo()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Debug,
            LogLevel.Info,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.AreEqual($"[{LogLevel.Debug}] {message}", _logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.AreEqual($"[{LogLevel.Info}] {message}", _logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.IsEmpty(_logText);
        _logText = "";
    }

    /// <summary>
    /// Test using debug and warn logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithDebugWarn()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Debug,
            LogLevel.Warn,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.AreEqual($"[{LogLevel.Debug}] {message}", _logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.AreEqual($"[{LogLevel.Warn}] {message}", _logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.IsEmpty(_logText);
        _logText = "";
    }

    /// <summary>
    /// Test using debug and error logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithDebugError()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Debug,
            LogLevel.Error,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.AreEqual($"[{LogLevel.Debug}] {message}", _logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.AreEqual($"[{LogLevel.Error}] {message}", _logText);
        _logText = "";
    }

    /// <summary>
    /// Test using info and Warn logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithInfoWarn()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Info,
            LogLevel.Warn,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.AreEqual($"[{LogLevel.Info}] {message}", _logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.AreEqual($"[{LogLevel.Warn}] {message}", _logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.IsEmpty(_logText);
        _logText = "";
    }

    /// <summary>
    /// Test using info and error logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithInfoError()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Info,
            LogLevel.Error,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.AreEqual($"[{LogLevel.Info}] {message}", _logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.AreEqual($"[{LogLevel.Error}] {message}", _logText);
        _logText = "";
    }

    /// <summary>
    /// Test using Warn and error logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithWarnError()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Warn,
            LogLevel.Error,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.AreEqual($"[{LogLevel.Warn}] {message}", _logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.AreEqual($"[{LogLevel.Error}] {message}", _logText);
        _logText = "";
    }

    /// <summary>
    /// Test using debug, info and Warn logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithDebugInfoWarn()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Debug,
            LogLevel.Info,
            LogLevel.Warn,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.AreEqual($"[{LogLevel.Debug}] {message}", _logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.AreEqual($"[{LogLevel.Info}] {message}", _logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.AreEqual($"[{LogLevel.Warn}] {message}", _logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.IsEmpty(_logText);
        _logText = "";
    }

    /// <summary>
    /// Test using debug, info and Error logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithDebugInfoError()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Debug,
            LogLevel.Info,
            LogLevel.Error,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.AreEqual($"[{LogLevel.Debug}] {message}", _logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.AreEqual($"[{LogLevel.Info}] {message}", _logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.AreEqual($"[{LogLevel.Error}] {message}", _logText);
        _logText = "";
    }

    /// <summary>
    /// Test using debug, Warn and error logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithDebugWarnError()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Debug,
            LogLevel.Warn,
            LogLevel.Error,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.AreEqual($"[{LogLevel.Debug}] {message}", _logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.AreEqual($"[{LogLevel.Warn}] {message}", _logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.AreEqual($"[{LogLevel.Error}] {message}", _logText);
        _logText = "";
    }

    /// <summary>
    /// Test using info, Warn and error logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithInfoWarnError()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Info,
            LogLevel.Warn,
            LogLevel.Error,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.IsEmpty(_logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.AreEqual($"[{LogLevel.Info}] {message}", _logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.AreEqual($"[{LogLevel.Warn}] {message}", _logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.AreEqual($"[{LogLevel.Error}] {message}", _logText);
        _logText = "";
    }

    /// <summary>
    /// Test using All logs
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoggingTestWithAllLogs()
    {
        var logConfig = (LogConfig)ScriptableObject.CreateInstance("LogConfig");
        logConfig._useLogLevels = new List<LogLevel>
        {
            LogLevel.Debug,
            LogLevel.Info,
            LogLevel.Warn,
            LogLevel.Error,
        };
        Logging.Instance.SetLogConfig(logConfig);

        // Test to print debug
        var message = "Debug";
        Logging.Instance.PrintDebug(message);
        Assert.AreEqual($"[{LogLevel.Debug}] {message}", _logText);
        _logText = "";

        // Test to info info
        message = "Info";
        Logging.Instance.PrintInfo(message);
        Assert.AreEqual($"[{LogLevel.Info}] {message}", _logText);
        _logText = "";

        // Test to warn info
        message = "Warn";
        Logging.Instance.PrintWarn(message);
        Assert.AreEqual($"[{LogLevel.Warn}] {message}", _logText);
        _logText = "";

        // Test to error info
        message = "Error";
        Logging.Instance.PrintError(message);
        Assert.AreEqual($"[{LogLevel.Error}] {message}", _logText);
        _logText = "";
    }

    private void OnLogMessageReceived(string logText, string stackTrace, LogType logType)
    {
        _logText = logText;
    }
}
