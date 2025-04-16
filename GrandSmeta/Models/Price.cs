namespace GrandSmeta.Models;

public class Price
{
    public string Value { get; set; }
    public string PZ { get; set; }
    public string OZ { get; set; }
    public string EM { get; set; }

    /// <summary>Дополнительная цена </summary>
    public string ZM { get; set; }
    public string MT { get; set; }

    /// <summary>Обоснование цены </summary>
    public string Comment { get; set; }

    /// <summary>Формула расчета</summary>
    public Fx[] Fx { get; set; }
}