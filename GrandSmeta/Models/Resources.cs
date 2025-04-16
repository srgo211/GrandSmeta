namespace GrandSmeta.Models;

public class Resources
{
    public ICollection<Tzr> Tzr { get; set; }
    public ICollection<Tzm> Tzm { get; set; }
    public ICollection<Mch> Mch { get; set; }
    public ICollection<Mat> Mat { get; set; }
}