namespace GrandSmeta.Models;

/// <summary>Настройки автозагрузки цен при составлении документа</summary>
public class CennikAutoLoad
{
    public DocLink DocLink { get; set; }

    /// <summary>Включено </summary>
    public string Enabled { get; set; }
    /// <summary>Поля для совпадения</summary>
    public string MatchFields { get; set; }

    /// <summary>Группы </summary>
    public string Groups { get; set; }

    /// <summary>Подгруппы</summary>
    public string SubGroups { get; set; }

    /// <summary></summary>
    public string Options { get; set; }

    /// <summary>Уровни цен для загрузки</summary>
    public string PriceTypes { get; set; }
}