using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandSmeta.Models.Itogs;



/// <summary>
/// Корневой контейнер Itog
/// </summary>
public class ItogRoot
{
    public ItogRes? ItogRes { get; set; }
}

/// <summary>
/// Контейнер итогов (ItogRes → список Itog)
/// </summary>
public class ItogRes
{
    public List<Itog> Items { get; set; } = [];
}

/// <summary>
/// Элемент <Itog>, поддерживает вложенность и содержит числовые/текстовые поля
/// </summary>
public class Itog
{
    public string? Caption { get; set; }
    public string? DataType { get; set; }
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
    public string? PZResult { get; set; }
    public string? EMResult { get; set; }
    public string? ZMResult { get; set; }

    /// <summary>
    /// Вложенные элементы <Itog>
    /// </summary>
    public List<Itog> Children { get; set; } = [];
}
