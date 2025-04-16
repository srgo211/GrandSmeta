namespace GrandSmeta.Models;

/// <summary>Виды работ документа </summary>
public class Vids_Rab
{
    /// <summary>тип справочника </summary>
    public string Type { get; set; }
    /// <summary>Файл Видов работ </summary>
    public string CatFile { get; set; }
    /// <summary>Файл норм НР и СП </summary>
    public string NrspFile { get; set; }
    /// <summary>Файл коэффициентов к НР и СП </summary>
    public string KfsFiles { get; set; }
    public ICollection<VidRab_Group> VidRab_Group { get; set; }
}