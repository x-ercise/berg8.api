using System;
using System.Collections.Generic;
using System.Linq;

namespace berg8.api
{
    public static partial class EnumExtension
    {
        public static T ToEnum<T>(this string stringType)
        {
            return (T)Enum.Parse(typeof(T), stringType);
        }

        public static string ToEnumName<T>(this int enumValue)
        {
            return Enum.GetName(typeof(T), enumValue);
        }

        public static IList<string> ToEnumMembers<T>(this T enumType)
        {
            return Enum.GetNames(typeof(T)).OfType<string>().ToList();
        }

    }
}
