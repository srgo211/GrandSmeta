namespace GrandSmeta.Models;

public class Indexes
{
    public string IndexesMode { get; set; }
    public string IndexesLinkMode { get; set; }
    public ICollection<CategoryIndexes> CategoryIndexes { get; set; }
}