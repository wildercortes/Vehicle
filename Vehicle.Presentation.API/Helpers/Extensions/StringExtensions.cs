﻿namespace Vehicle.Presentation.API.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string s)
        {
            return char.ToLowerInvariant(s[0]) + s.Substring(1);
        }
    }
}
