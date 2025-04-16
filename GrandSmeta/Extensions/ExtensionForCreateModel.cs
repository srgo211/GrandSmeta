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
            object objValue = value;
            if (type == typeof(string)) objValue = value;
            if (type == typeof(int)) objValue = value.ToInt();
            if (type == typeof(long)) objValue = value;
            if (type == typeof(float)) objValue = value;
            if (type == typeof(double)) objValue = value.ToDouble();
            if (type == typeof(decimal)) objValue = value.ToDecimal();
            if (type == typeof(DateTime)) objValue = Convert.ToDateTime(value);
            if (type == typeof(Guid)) objValue = value;
            if (type == typeof(DateTimeOffset)) objValue = value;
            if (type == typeof(TimeSpan)) objValue = value;

            return objValue;
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
