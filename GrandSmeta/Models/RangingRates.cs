namespace GrandSmeta.Models;

/// <summary>Нормы малообъемных ресурсов по группам</summary>
public class RangingRates
{
    /// <summary>Норма малообъемных ресурсов для механизмов </summary>
    public string Mch { get; set; }
    /// <summary>Норма малообъемных ресурсов для материалов </summary>
    public string Mat { get; set; }
    /// <summary>Норма малообъемных ресурсов Трудозатрат </summary>
    public string Tz { get; set; }
    /// <summary>Норма малообъемных ресурсов Оборудования </summary>
    public string Eq { get; set; }
    /// <summary>Норма малообъемных ресурсов Перевозка </summary>
    public string Tr { get; set; }
    /// <summary>Норма малообъемных ресурсов Погрузка/разгрузка </summary>
    public string Load { get; set; }
}