namespace GrandSmeta.Models;

/// <summary>Затраты труда рабочих </summary>
public class Tzr : ResourseInfo
{
    /// <summary>Средний разряд рабочих, только для TZR </summary>
    public string WorkClass { get; set; }
}