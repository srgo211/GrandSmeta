namespace GrandSmeta.Models;

/// <summary>Коэффициенты, применяемые к группе позиций </summary>
public class Koefficients
{
    /// <summary>Коэффициенты к итогам </summary>
    public ICollection<K> K { get; set; }
}