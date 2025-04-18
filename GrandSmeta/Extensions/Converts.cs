﻿using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

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

        // Обработка экспоненциальной записи (научной формы)
        if (quantity.Contains('E', StringComparison.OrdinalIgnoreCase))
        {
            if (decimal.TryParse(quantity.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out var expResult))
            {
                return expResult;
            }

            return default;
        }

        // Стандартное преобразование (используем текущую культуру или настраиваемую)
        if (decimal.TryParse(quantity, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
        {
            return result;
        }

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

}

