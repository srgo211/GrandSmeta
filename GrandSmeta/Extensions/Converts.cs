using GrandSmeta.Services;
using System.Globalization;

namespace GrandSmeta.Extensions;

public static class Converts
{

    /// <summary>
    /// Преобразует строку в decimal, учитывая экспоненциальную форму и культуру.
    /// </summary>
    /// <param name="quantity">Строка со значением.</param>
    /// <returns>Преобразованное значение или 0 при ошибке.</returns>
    public static decimal ToDecimal(this string quantity)
    {
        if (string.IsNullOrWhiteSpace(quantity)) return default;

        quantity = quantity.Trim();

        // Обработка экспоненты
        if (quantity.Contains('E', StringComparison.OrdinalIgnoreCase))
            quantity = quantity.Replace(",", ".");

        // Попробуем с русской запятой
        if (decimal.TryParse(quantity, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out var ruResult))
            return ruResult;

        // Попробуем с точкой (InvarantCulture)
        if (decimal.TryParse(quantity.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out var invResult))
            return invResult;



        return default;
    }

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


    public static bool Matches(this ItogDataType value, ItogDataType filter)
    {
        if(filter == ItogDataType.All) return true;
        var res = (filter & value) != 0;
        return res;
    }

    
    public static bool Matches(this ItogScope value, ItogScope filter)
    {
        if (filter == ItogScope.All) return true;

        var res = (filter & value) != 0;
        return res;
    }


    public static string RemoveSpacesStackalloc(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        Span<char> buffer = stackalloc char[50]; // фиксированный стек-буфер
        int pos = 0;

        foreach (char c in input)
        {
            if (c != ' ')
                buffer[pos++] = c;
        }

        return new string(buffer.Slice(0, pos));
    }
}

