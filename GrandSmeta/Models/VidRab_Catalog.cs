namespace GrandSmeta.Models;

/// <summary>Справочник видов работ </summary>
public class VidRab_Catalog
{
    /// <summary>Наименование справочника </summary>
    public string Caption { get; set; }

    /// <summary>Виды работ документа </summary>
    public ICollection<Vids_Rab> Vids_Rab { get; set; }
}