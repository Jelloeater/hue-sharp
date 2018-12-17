using NLog;
using NLog.Config;
using NLog.Targets;

namespace libs
{
    public static class Logging
    {
        public static Logger GetLogger()
        {
            var config = new LoggingConfiguration();
            var logfile = new FileTarget("logfile") {FileName = "HueSharp.log"};
            var logconsole = new ConsoleTarget("logconsole");
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            LogManager.Configuration = config;
            var logger = LogManager.GetCurrentClassLogger();
            return logger;
        }
    }
}
