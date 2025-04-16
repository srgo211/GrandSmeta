namespace GrandSmeta.Models;

public class IOsInfo
{
    public string OSChapter { get; set; }
    public string LinkType { get; set; }
    public ICollection<CCChapter> CCChapter { get; set; }
}