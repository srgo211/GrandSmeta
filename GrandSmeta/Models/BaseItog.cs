namespace GrandSmeta.Models;

public class BaseItog
{
    /// <summary>Условие, из-за которого позиция не попала в расчет итогов по смете</summary>
    public string BadPosReason { get; set; }

    /// <summary>для строк стоимость единицы позиции</summary>
    public string Status { get; set; }

    /// <summary>Итоговое значение соответствующего типа Трудозатрат рабочих, занятых обслуживанием машин и механизмов</summary>
    public string TM { get; set; }

    /// <summary>Итоговое значение соответствующего типа Трудозатрат основных рабочих</summary>
    public string TZ { get; set; }

    /// <summary>Итоговое значение соответствующего типа Материалов</summary>
    public string MT { get; set; }

    /// <summary>Итоговое значение соответствующего типа Заработой платы рабочих, занятых обслуживанием машин и механизмов</summary>
    public string ZM { get; set; }

    /// <summary>Итоговое значение соответствующего типа Эксплуатации машин и механизмов</summary>
    public string EM { get; set; }

    /// <summary>Итоговое значение соответствующего типа Заработой платы основных рабочих</summary>
    public string OZ { get; set; }


    /// <summary>Итоговое значение соответствующего типа Прямых затрат или общей стоимости</summary>
    public string PZ { get; set; }

    /// <summary>Тип строки итогов</summary>
    public string DataType { get; set; }

    /// <summary>Заголовок строки итогов</summary>
    public string Caption { get; set; }

    /// <summary>результирующий коэффициент для ОЗП</summary>
    public string OZResult { get; set; }

    /// <summary>результирующий коэффициент для ТЗ основлных рабочих</summary>
    public string TZResult { get; set; }

    /// <summary>результирующий коэффициент для Эксплуатации машин и механизмов</summary>
    public string EMResult { get; set; }

    /// <summary>результирующий коэффициент для ЗПМ</summary>
    public string ZMResult { get; set; }

    /// <summary>результирующий коэффициент для Трудозатрат Механизаторов</summary>
    public string TMResult { get; set; }

    /// <summary>результирующий коэффициент для Материалов</summary>
    public string MTResult { get; set; }
    /// <summary>результирующий коэффициент для Прямых затрат</summary>
    public string PZResult { get; set; }
    /// <summary>Код </summary>
    public string Code { get; set; }
    /// <summary>На единицу в текущих ценах </summary>
    public string ForOneBase { get; set; }
    /// <summary>На единицу в текущих ценах </summary>
    public string ForOneCurr { get; set; }
    /// <summary>Итого в базисных ценах </summary>
    string TotalBase { get; set; }
    /// <summary>Итого в текущих ценах </summary>
    public string TotalCurr { get; set; }
    /// <summary>На единицу </summary>
    public string ForOne { get; set; }
    /// <summary>Итого</summary>
    public string Total { get; set; }
    /// <summary>Количество на единицу</summary>
    public string QuantityForOne { get; set; }
    /// <summary>Итоговое количество</summary>
    public string QuantityTotal { get; set; }
}