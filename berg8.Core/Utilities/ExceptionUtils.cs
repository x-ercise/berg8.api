using System;

namespace Berg8.Core.Utilities
{
    public static class ExceptionUtils
    {
        public static void ThrowIfNull(this object source, string paramName = null, string message = null)
        {
            if (source == null)
                throw new ArgumentNullException(paramName, message);
        }
    }
}
