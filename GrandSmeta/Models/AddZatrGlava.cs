namespace GrandSmeta.Models;

public class AddZatrGlava
{
    /// <summary>номер главы </summary>
    public string Glava { get; set; }

    /// <summary>Начисление </summary>
    public ICollection<AddZatr> AddZatr { get; set; }
}