namespace GrandSmeta.Models;

/// <summary>Начисление </summary>
public class AddZatr
{
    /// <summary>Наименование </summary>
    public string Caption { get; set; }
    /// <summary>Опции расчета </summary>
    public string Options { get; set; }
    /// <summary>Идентификатор </summary>
    public string Identifier { get; set; }
    /// <summary>Формула расчета </summary>
    public string Formula { get; set; }
    /// <summary>Значение </summary>
    public string Value { get; set; }
    /// <summary>Уровень расчета </summary>
    public string Level { get; set; }
}