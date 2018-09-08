using System;
using System.Collections.Generic;

namespace Berg8.Core.Utilities
{
    public static class CollectionUtils
    {
        public static void ForEach<T>(this ICollection<T> source, Action<T> action)
        {
            source.ThrowIfNull("source");
            action.ThrowIfNull("action");

            foreach (var item in source)
                action(item);
        }
    }
}
