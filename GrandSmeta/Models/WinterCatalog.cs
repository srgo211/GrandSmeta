namespace GrandSmeta.Models;

public class WinterCatalog
{
    public string WinterMode { get; set; }
    public string WinterLinkMode { get; set; }
    public ICollection<CommonWinterK> CommonWinterK { get; set; }
}