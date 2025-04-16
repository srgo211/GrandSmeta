namespace GrandSmeta.Models;

public class BaseFilds
{
    /// <summary>Наименование</summary>
    public string Caption { get; set; }

    /// <summary>Номер позиции в соответствии с принятой в смете нумерацией</summary>
    public string Number { get; set; }

    /// <summary>Обоснование (шифр) позиции</summary>
    public string Code { get; set; }

    /// <summary>Единица измерения</summary>
    public string Units { get; set; }

    /// <summary>Физ. Объем (Количество) - пишется результирующая формула физобъема или число</summary>
    public string Quantity { get; set; }

    /// <summary>Опции расчёта позиции</summary>
    public string Options { get; set; }

    /// <summary>Идентификатор ресурса для использования в формулах </summary>
    public string Identifier { get; set; }

    /// <summary>Код применяемого индекса </summary>
    public string IndexCode { get; set; }

    /// <summary> Класс груза</summary>
    public string Cargo { get; set; }

    /// <summary>Масса брутто</summary>
    public string Mass { get; set; }

    public int Guid { get; set; }
    public int IdPosition { get; set; }


    /// <summary>Стоимость ресурсов в базисных ценах</summary>
    public Price PriceBase { get; set; }

    /// <summary>Стоимость ресурсов в текущих ценах </summary>
    public Price PriceCurr { get; set; }
    public Koefficients Koefficients { get; set; }

    public Tzm2022 Tzm2022 { get; set; }
}