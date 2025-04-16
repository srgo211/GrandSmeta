namespace GrandSmeta.Models;

/// <summary>Группа видов работ</summary>
public class VidRab_Group
{
    /// <summary>уникальный идентификатор группы </summary>
    public string ID { get; set; }
    /// <summary>Наименование группы видов работ </summary>
    public string Caption { get; set; }
    /// <summary>код индекса пересчета </summary>
    public string IndexCode { get; set; }
    public ICollection<Vid_Rab> Vid_Rab { get; set; }
}