namespace GrandSmeta.Models;

public class Itog
{
    /// <summary>Итоги для Базисно-Индексного метода</summary>
   public ICollection<BaseItog> ItogBim { get; set; }
    /// <summary>Итоги для Базисного метода</summary>
    public ICollection<BaseItog> ItogNoIdx { get; set; }
    /// <summary>Итоги для Ресурсного метода </summary>
    public ICollection<BaseItog> ItogRes { get; set; }
}