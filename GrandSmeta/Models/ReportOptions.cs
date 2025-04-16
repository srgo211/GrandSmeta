namespace GrandSmeta.Models;

/// <summary>Настройкии отображения ведомости ресурсов по смете </summary>
public class ReportOptions
{
    /// <summary>Режим работы</summary>
    public string Mode { get; set; }
    /// <summary>Настройки ранжирования</summary>
    public string Options { get; set; }
    /// <summary>Коэффициент корреляции </summary>
    public string Kk { get; set; }

    /// <summary>Группы ресурсов для ранжирования</summary>
    public string RangingGroups { get; set; }
    /// <summary> </summary>
    public string RangingMode { get; set; }
    /// <summary>Нормы малообъемных ресурсов по группам </summary>
    public ICollection<RangingRates> RangingRates { get; set; }
}