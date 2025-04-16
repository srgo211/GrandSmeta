namespace GrandSmeta.Models;

public class Itog
{
    /// <summary>Итоги для Базисно-Индексного метода</summary>
    ICollection<BaseItog> ItogBim { get; set; }
    /// <summary>Итоги для Базисного метода</summary>
    ICollection<BaseItog> ItogNoIdx { get; set; }
    /// <summary>Итоги для Ресурсного метода </summary>
    ICollection<BaseItog> ItogRes { get; set; }
}