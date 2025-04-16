namespace GrandSmeta.Models;

/// <summary>Коэффициент </summary>
public class K
{
    /// <summary>Наименование коэффициента</summary>
    public string Caption { get; set; }

    /// <summary>Параметры применения коэффициента при его учете в документе</summary>
    public string Options { get; set; }

    /// <summary>Уровень коэффициента</summary>
    public string Level { get; set; }

    /// <summary>Обоснование коэффициента (ссылка на обосновывающий документ)</summary>
    public string Code { get; set; }

    /// <summary>Значение коэффициента к ЗП</summary>
    public string Value_PZ { get; set; }

    /// <summary>Значение коэффициента к ОЗП</summary>
    public string Value_OZ { get; set; }

    /// <summary>Значение коэффициента к ЭМ</summary>
    public string Value_EM { get; set; }

    /// <summary>Значение коэффициента к МТ</summary>
    public string Value_MT { get; set; }

    /// <summary>Значение коэффициента к ЗПМ</summary>
    public string Value_ZM { get; set; }

    /// <summary>Применение к-та ко всем видам работ в смете</summary>
    public string AllVidRabs { get; set; }

    /// <summary>Коды видов работ позиций с базисным уровнем цен 2001г и выше для применения к-та</summary>
    public string VrsLinks { get; set; }

    /// <summary>Формула к-та </summary>
    public string Formula { get; set; }

    /// <summary>Тип используемого к-та Formula - в виде формулы</summary>
    public string Kind { get; set; }
    /// <summary>Применение к-та ко всем разделам в смете</summary>
    public string AllChapters { get; set; }

    /// <summary>Коды групп видов работ для применения к-та </summary>
    public string VrGroupsLinks { get; set; }

    /// <summary>Коды разделов документа для применения к-та</summary>
    public string ChaptersLinks { get; set; }
}