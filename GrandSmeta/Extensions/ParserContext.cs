using GrandSmeta.Models;

namespace GrandSmeta.Extensions;

/// <summary>
/// Контекст загрузки XML-документа, хранящий промежуточное состояние между узлами.
/// </summary>
public sealed class ParserContext
{
    /// <summary>
    /// Главный объект документа, который наполняется в процессе парсинга.
    /// </summary>
    public Document Document { get; set; } = new();

    /// <summary>
    /// Текущая обрабатываемая глава.
    /// </summary>
    public Chapter? CurrentChapter { get; set; }

    /// <summary>
    /// Текущая обрабатываемая позиция.
    /// </summary>
    public Position? CurrentPosition { get; set; }

    /// <summary>
    /// Текущие коэффициенты, действующие на ресурсы или позиции.
    /// </summary>
    public Koefficients? CurrentKoefficients { get; set; }

    /// <summary>
    /// Базовая цена, применимая к текущей сущности.
    /// </summary>
    public Price? CurrentPriceBase { get; set; }

    /// <summary>
    /// Текущая цена (актуальная) для объекта.
    /// </summary>
    public Price? CurrentPriceCurr { get; set; }

    /// <summary>
    /// Модель ТЗМ 2022 года, если применяется.
    /// </summary>
    public Tzm2022? CurrentTzm2022 { get; set; }

    /// <summary>
    /// Уникальный числовой идентификатор (GUID), инкрементируется по мере создания объектов.
    /// </summary>
    public int GuidCounter { get; set; } = 1;

    /// <summary>
    /// Счётчик позиций, используемый для присвоения идентификаторов.
    /// </summary>
    public int IdPositionCounter { get; set; } = 0;

    /// <summary>
    /// Флаг, указывающий, находится ли текущая позиция в блоке <Replaced>.
    /// </summary>
    public bool IsReplaced { get; set; } = false;

    /// <summary>
    /// Флаг, определяющий, что коэффициенты применимы к позиции, а не к документу.
    /// </summary>
    public bool IsKoefPosition { get; set; } = false;

    /// <summary>
    /// Список дополнительных затрат, временно накапливаемых.
    /// </summary>
    public List<AddZatr> CurrentAddZatrList { get; set; } = new();

    /// <summary>
    /// Текущий список видов работ (верхний уровень).
    /// </summary>
    public List<Vids_Rab> CurrentVids_Rab { get; set; } = new();

    /// <summary>
    /// Текущие группы видов работ.
    /// </summary>
    public List<VidRab_Group> CurrentVidRab_Group { get; set; } = new();

    /// <summary>
    /// Текущий список конкретных работ внутри группы.
    /// </summary>
    public List<Vid_Rab> CurrentVid_Rab { get; set; } = new();
}

