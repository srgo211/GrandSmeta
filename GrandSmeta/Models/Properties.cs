namespace GrandSmeta.Models;

public class Properties
{
    /// <summary>Регистрационный номер сметы</summary>
    public string RegNum { get; set; }
    /// <summary>Наименование сметы (вида работ), передаваемое в печатную форму </summary>
    public string Description { get; set; }
    /// <summary>Наименование пускового комплекса / очереди </summary>
    public string Stage { get; set; }

    /// <summary>Наименование объекта строительства </summary>
    public string Object { get; set; }
    /// <summary>Наименование стройки</summary>
    public string Constr { get; set; }
    /// <summary>Локальный номер сметы </summary>
    public string LocNum { get; set; }
    /// <summary>Комментарии, пояснения к документу </summary>
    public string Comment { get; set; }
}