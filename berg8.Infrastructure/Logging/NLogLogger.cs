using System;
using Berg8.Core.Utilities;
using NLog;

namespace Berg8.Infrastructure.Logging
{
    public class NLogLogger : Berg8.Core.Utilities.ILogger
    {
        private static readonly Lazy<NLogLogger> LazyLogger = new Lazy<NLogLogger>(() => new NLogLogger()); 
        private static readonly Lazy<NLog.Logger> LazyNLogger= new Lazy<Logger>(LogManager.GetCurrentClassLogger);

        private NLogLogger() { }

        public static Berg8.Core.Utilities.ILogger Instance
        {
            get { return LazyLogger.Value; }
        }

        public void Log(string message)
        {
            LazyNLogger.Value.Info(message);
        }

        public void Log(Exception exception)
        {
            LazyNLogger.Value.Error(exception);
        }
    }
}
