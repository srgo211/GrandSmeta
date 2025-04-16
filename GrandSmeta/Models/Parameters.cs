namespace GrandSmeta.Models;

public class Parameters
{
    /// <summary>Набор настроек расчета локальной сметы </summary>
    public string Options { get; set; }

    /// <summary>Основной уровень цен при расчетах в базисных ценах </summary>
    public string BasePrices { get; set; }

    /// <summary>Виды работ для расчета НР и СП при расчетах в базисных ценах </summary>
    public string BaseCalcVrs { get; set; }

    /// <summary>Количество цифр для округления трудозатрат и количества у машин и механизмов </summary>
    public string TzDigits { get; set; }

    /// <summary>Обработка погрешности округления</summary>
    public string BlockRoundMode { get; set; }

    /// <summary>Способ формирования общей стоимости позиций при расчете в Базисных ценах</summary>
    public string MultKPosCalcMode { get; set; }

    /// <summary>Номер температурной зоны </summary>
    public string TempZone { get; set; }
    public string TsnTempZone { get; set; }

    /// <summary>Количество значащих цифр для округления расхода материалов</summary>
    public string MatDigits { get; set; }

    /// <summary>Округление рассчитанного расхода материалов </summary>
    public string MatRoundMode { get; set; }

    /// <summary>Настройка округления результата перемножения коэффициентов</summary>
    public string PosKDigits { get; set; }

    /// <summary>Опции расчета итогов</summary>
    public string ItogOptions { get; set; }

    /// <summary>Элемент расчета, начиная с которого все остальные элементы рассчитываются в итогах сметы </summary>
    public string FirstItogItem { get; set; }

    /// <summary>Настройка уровня, до которого детализируются итоги</summary>
    public string ItogExpandTo { get; set; }

    /// <summary>Количество для вычисления Показателя единичной стоимости</summary>
    public string UnitsQty { get; set; }

    /// <summary>Единица измерения показателя единичной стоимости</summary>
    public string Units { get; set; }

    /// <summary>наименование файла - шаблона настроек расчёта</summary>
    public string PropsConfigName { get; set; }

    /// <summary>Наименование показателя единичной стоимсоти Документа </summary>
    public string CostPerUnitDescr { get; set; }

    /// <summary>Обоснование текущей цены</summary>
    public string CurrPricesReason { get; set; }

    /// <summary>Методика (2020,2022,2024)</summary>
    public string Mode2020Order { get; set; }

    public ICollection<CommonNK> CommonNK { get; set; }
    public ICollection<CommonPK> CommonPK { get; set; }
    public ICollection<Numbering> Numbering { get; set; }
}
