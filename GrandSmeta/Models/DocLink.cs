namespace GrandSmeta.Models;

/// <summary> </summary>
public class DocLink
{
    /// <summary>Наименование документа </summary>
    public string Caption { get; set; }

    /// <summary>Путь к документу (ссылка)</summary>
    public string Link { get; set; }

    /// <summary>Комментарий </summary>
    public string Comment { get; set; }
}