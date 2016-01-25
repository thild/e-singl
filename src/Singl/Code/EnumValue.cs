//http://stackoverflow.com/questions/25643357/json-net-custom-serialization-of-a-enum-type-with-data-annotation

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Newtonsoft.Json;
namespace Singl.Extensions
{

    public class EnumValue
    {
        public int Value { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }
        public string Description { get; set; }
    }

    public static class EnumHelpers
    {
        public static EnumValue GetEnumValue(object value, Type enumType)
        {
            MemberInfo member = enumType.GetMember(value.ToString())[0];

            DisplayAttribute attribute =
                member.GetCustomAttribute<DisplayAttribute>();
            
            return new EnumValue
            {
                Value = (int)value,
                Name = Enum.GetName(enumType, value),
                Label = attribute?.Name ?? Enum.GetName(enumType, value),
                Description = attribute?.Description ?? string.Empty
            };
        }

        public static EnumValue[] GetEnumValues(Type enumType)
        {
            Array values = Enum.GetValues(enumType);

            EnumValue[] result = new EnumValue[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                result[i] = GetEnumValue(
                    values.GetValue(i),
                    enumType);
            }

            return result;
        }
    }

    public class EnumTypeConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            Console.WriteLine(new string('#', 40) );
            Console.WriteLine("EnumTypeConverter - WriteJson");
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            EnumValue[] values = EnumHelpers.GetEnumValues((Type)value);

            serializer.Serialize(writer, values);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override bool CanRead { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            Console.WriteLine(new string('#', 40) );
            Console.WriteLine("EnumTypeConverter - CanConvert");
            return typeof(Type).IsAssignableFrom(objectType);
        }
    }


    public class EnumValueConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            Console.WriteLine(new string('#', 40) );
            Console.WriteLine("EnumValueConverter - WriteJson");
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            EnumValue result = EnumHelpers.GetEnumValue(value, value.GetType());

            serializer.Serialize(writer, result);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override bool CanRead { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            Console.WriteLine(new string('#', 40) );
            Console.WriteLine("EnumValueConverter - CanConvert");
            //return objectType.IsAbstract;
            return true;
        }
    }

}
