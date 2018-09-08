using System;

namespace Berg8.Core.Utilities
{
    public interface ILogger
    {
        void Log(string message);
        void Log(Exception exception);
    }
}
