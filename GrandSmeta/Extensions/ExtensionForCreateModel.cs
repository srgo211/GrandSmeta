using System.Reflection;
using System.Xml;

namespace GrandSmeta.Extensions;

public static class ExtensionForCreateModel
{
    public static T CreateDataModel<T>(this Dictionary<string, string> dictionary) where T : new()
    {
        T model = new T();
        Type modelType = typeof(T);

        if (dictionary is null || dictionary.Count == 0) return model;

        foreach (KeyValuePair<string, string> pair in dictionary)
        {
            string key = pair.Key;
            string value = pair.Value;

            PropertyInfo property = modelType.GetProperty(key);
            if (property != null && property.CanWrite)
            {
                Type propertyType = property.PropertyType;

                object? objValue = ConvertValue(value, propertyType);

                property.SetValue(model, objValue);
            }
        }

        return model;
    }

    private static object? ConvertValue(string value, Type type)
    {
        try
        {
            if (type == typeof(string)) return value;
            if (type == typeof(int)) return value.ToInt(); ;
            if (type == typeof(long)) return long.Parse(value);
            if (type == typeof(float)) return float.Parse(value);
            if (type == typeof(double)) return value.ToDouble();
            if (type == typeof(decimal)) return value.ToDecimal();
            if (type == typeof(DateTime)) return DateTime.Parse(value);
            if (type == typeof(Guid)) return Guid.Parse(value);
            if (type == typeof(DateTimeOffset)) return DateTimeOffset.Parse(value);
            if (type == typeof(TimeSpan)) return TimeSpan.Parse(value);

            // Nullable<T> (например decimal?, int?, enum?)
            Type? underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                // Пустая строка — это null
                if (string.IsNullOrWhiteSpace(value)) return null;
                return ConvertValue(value, underlyingType);
            }

            // Enum
            if (type.IsEnum)
            {
                if (!string.IsNullOrWhiteSpace(value))

                    return Enum.Parse(type, value.RemoveSpacesStackalloc(), ignoreCase: true);
            }

            return null; // Неизвестный тип
        }
        catch
        {
            return null;
        }
    }


    public static Dictionary<string, string> GetAtributes(this XmlReader reader)
    {

        if (reader is null || !reader.HasAttributes) return default;

        Dictionary<string, string> dic = new();
        for (int i = 0; i < reader.AttributeCount; i++)
        {
            reader.MoveToAttribute(i);

            string name = reader.Name;
            string value = reader.Value;

            dic.Add(name, value);

        }
        reader.MoveToElement();

        return dic;



    }

}
