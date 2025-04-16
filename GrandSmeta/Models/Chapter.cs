namespace GrandSmeta.Models;

/// <summary>Раздел</summary>
public class Chapter
{
    /// <summary>Внутренний уникальный системный номер раздела </summary>
    public string SysID { get; set; }
    /// <summary>Наименование раздела </summary>
    public string Caption { get; set; }
    /// <summary>код индекса пересчета </summary>
    public string IndexCode { get; set; }
    /// <summary>Наименование показателя единичной стоимости раздела </summary>
    public string CostPerUnitDescr { get; set; }
    /// <summary>Количество для расчета показателя единичной стоимости раздела </summary>
    public string UnitsQty { get; set; }
    /// <summary>Единица измерения показателя единичной стоимости раздела </summary>
    public string Units { get; set; }
    /// <summary>Позиции локальной сметы </summary>
    public ICollection<Position> Position { get; set; }
    /// <summary>заголовок</summary>
    public ICollection<Header> Header { get; set; }

    /// <summary>Строка-Комментарий</summary>
    public ICollection<Comment> Comment { get; set; }

    /// <summary>Рассчитанный итог по разделу</summary>
    public Itog Itog { get; set; }
    public int Guid { get; set; }
}