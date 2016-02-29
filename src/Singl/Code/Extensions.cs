using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Singl.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var ca = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();

            return ca == null ? enumValue.ToString() : ca.Name;
        }

        public static T ToEnum<T>(this string value, T defaultValue)
            where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        }
    }

}

namespace Singl.Helpers
{
    public static class CsvHelper
    {
        public static IList<dynamic> Read(string fileName)
        {
            var lines = new List<dynamic>();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var header = new List<string>();
                    var firstLine = true;
                    while (!sr.EndOfStream)
                    {
                        if (firstLine)
                        {
                            firstLine = false;
                            header.AddRange(sr.ReadLine().Split(';'));
                        }
                        var i = 0;
                        var tuple = new ExpandoObject();
                        foreach (var s in sr.ReadLine().Split(';'))
                        {
                            (tuple as IDictionary<string, dynamic>).Add(header[i++], s);
                        }
                        lines.Add(tuple);
                    }
                }
            }
            return lines;
        }
    }
}