﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace SquareSpaceSharp.Extensions
{
    /// <summary>
    /// Enum Extension Method
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Reads and uses the enum's <see cref="EnumMemberAttribute"/> for serialization.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSerializedString(this Enum input)
        {
            string name = input.ToString();
            var info = input.GetType().GetTypeInfo().DeclaredMembers.Where(i => i.Name == name);

            if (info.Count() > 0)
            {
                var attribute = info.First().GetCustomAttribute<EnumMemberAttribute>();

                if (attribute != null)
                {
                    return attribute.Value;
                }
            }

            return name.ToLower();
        }

        /// <summary>
        /// Convert list of Enums to a comma seperated string
        /// </summary>
        public static string EnumListToString<T>(IEnumerable<T> enumList)
        {
            var list = new List<string>();

            if (enumList != null && enumList.Any())
            {
                foreach (var enumItem in enumList)
                {
                    list.Add((enumItem as Enum).ToSerializedString());
                }
            }
            return string.Join(",", list);
        }
    }
}
