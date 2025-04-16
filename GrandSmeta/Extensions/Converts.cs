using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace GrandSmeta.Extensions;

public static class Converts
{
    public static decimal? ToDecimalIsNull(this string quantity)
    {
        if (String.IsNullOrEmpty(quantity)) return default(decimal);
        if (String.IsNullOrWhiteSpace(quantity)) return default(decimal);



        if (quantity.ToUpper().Contains("E"))
        {
            if (decimal.TryParse(quantity.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out decimal f))
            {
                return f;
            }
            else
            {
                return default(decimal);
            }
        }
        else
        {
            decimal.TryParse(quantity.Replace(".", ","), out decimal result);
            return result;
        }
    }

    public static decimal ToDecimal(this string quantity)
    {
        if (String.IsNullOrEmpty(quantity)) return default(decimal);
        if (String.IsNullOrWhiteSpace(quantity)) return default(decimal);


        if (quantity.ToUpper().Contains("E"))
        {
            if (decimal.TryParse(quantity.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out decimal f))
            {
                return f;
            }
            return default(decimal);

        }
        decimal.TryParse(quantity.Replace(".", ","), out decimal result);
        return result;

    }

    public static decimal ToDecimal(this double quantity) => Convert.ToDecimal(quantity);

    public static double ToDouble(this string data)
    {
        if (String.IsNullOrEmpty(data)) return default(double);
        if (String.IsNullOrWhiteSpace(data)) return default(double);

        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
        data = data.Replace(",", ".").Trim();

        double.TryParse(data, NumberStyles.Number, culture, out double result);
        return result;


    }

    public static int ToInt(this string quantity)
    {
        if (String.IsNullOrWhiteSpace(quantity)) return default(int);

        int.TryParse(quantity.Trim(), out int result);
        return result;
    }

    public static long ToLong(this string quantity)
    {
        if (String.IsNullOrWhiteSpace(quantity)) return default(long);

        long.TryParse(quantity.Trim(), out long result);
        return result;
    }

    public static bool ToBool(this string quantity)
    {
        if (String.IsNullOrWhiteSpace(quantity)) return false;

        if (quantity.Trim() == "1" || quantity.Trim().ToLower() == "true") return true;
        return false;
    }

    public static decimal ToDecimal(this XmlNode xmlNode, string namedItem)
    {
        if (xmlNode == null) return default(decimal);


        XmlNode node = xmlNode.Attributes.GetNamedItem(namedItem);
        if (node == null) return default(decimal);

        decimal res = node.Value.ToDecimal();
        return res;

    }

    public static int ToNumberXML(this XmlNode xmlNode)
    {
        XmlNode attrPositionNumber = xmlNode.Attributes.GetNamedItem("Number");
        int numberXml = int.Parse(attrPositionNumber.Value);
        //string globalId = numberXml.ToString();//Guid.NewGuid().ToString();
        return numberXml;
    }


    /// <summary>
    /// Получаем из текста числовое значение
    /// </summary>
    /// <param name="text">текст с числовым значением</param>
    /// <returns></returns>
    public static decimal ToDecimalFromText(this string text)
    {
        const string pattern = "[0-9]*[.,][0-9]+";

        if (String.IsNullOrEmpty(text)) return default(decimal);
        text = text.Replace(" ", "").Replace(" ", "");
        string res = Regex.Match(text, pattern).ToString();

        return res.ToDecimal();
    }


   

}

