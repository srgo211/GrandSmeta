using GrandSmeta.Services;

namespace GrandSmeta.Models.Itogs;

internal record ItogNode(int Depth, Dictionary<string, string> Attributes);


/// <summary>
/// Элемент <Itog>, поддерживает вложенность и содержит числовые/текстовые поля
/// </summary>
public class Itog
{
    public string? Caption { get; set; }
    public ItogDataType DataType { get; set; }
    public string? Status { get; set; }

    // Значения стоимости и объёмов
    public string? PZ { get; set; }    // Прямые затраты
    public string? OZ { get; set; }    // Общие затраты
    public string? EM { get; set; }    // Эксплуатация машин
    public string? ZM { get; set; }    // Заработная плата машинистов
    public string? MT { get; set; }    // Материалы
    public string? TZ { get; set; }    // Трудозатраты (в нормо-часах)
    public string? TM { get; set; }    // Трудозатраты (в чел.-днях)

    // Значения после применения коэффициентов
    public decimal? PZResult { get; set; }
    public decimal? EMResult { get; set; }
    public decimal? ZMResult { get; set; }
    public decimal? OZResult { get; set; }
    public decimal? MTResult { get; set; }
    public decimal? TZResult { get; set; }
    public decimal? TMResult { get; set; }

    /// <summary>
    /// Вложенные элементы <Itog>
    /// </summary>
    public List<Itog> Children { get; set; } = [];
}

public sealed class ParserContextItog
{      
    public Dictionary<string, List<Itog>> ItogsByPosition { get; } = new();
    public Dictionary<string, List<Itog>> ItogsByChapter { get; } = new();
    public Dictionary<string, List<Itog>> ItogsByDocument { get; } = new();
}