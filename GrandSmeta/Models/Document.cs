namespace GrandSmeta.Models;


public class Document
{
    public string Generator { get; set; }
    public string ProgramVersion { get; set; }
    public string DocumentType { get; set; }
    public string Comment { get; set; }

    public Properties Properties { get; set; }
    public GsDocSignatures GsDocSignatures { get; set; }
    public RegionalK RegionalK { get; set; }
    public TerZoneK TerZoneK { get; set; }
    public Koefficients Koefficients { get; set; }
    public WinterCatalog WinterCatalog { get; set; }
    public RegionInfo RegionInfo { get; set; }
    public FRSN_Info FRSN_Info { get; set; }
    public Parameters Parameters { get; set; }
    public Indexes Indexes { get; set; }



    public AddZatrats AddZatrats { get; set; }
    public OsInfo OsInfo { get; set; }

    public CennikAutoLoad CennikAutoLoad { get; set; }

    public VidRab_Catalog VidRab_Catalog { get; set; }
    public Chapters Chapters { get; set; }
    public ReportOptions ReportOptions { get; set; }
    public Variables Variables { get; set; }
  
}