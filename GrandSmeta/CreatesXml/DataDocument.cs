using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

internal class DataDocument
{
    internal static async Task CreateDocumentAsync(XmlWriter writer, Document data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "Document", null);

        if (!String.IsNullOrWhiteSpace(data.Generator)) await writer.WriteAttributeStringAsync(null, "Generator", null, data?.Generator);
        if (!String.IsNullOrWhiteSpace(data.ProgramVersion)) await writer.WriteAttributeStringAsync(null, "ProgramVersion", null, data?.ProgramVersion);
        if (!String.IsNullOrWhiteSpace(data.DocumentType)) await writer.WriteAttributeStringAsync(null, "DocumentType", null, data?.DocumentType);
        if (!String.IsNullOrWhiteSpace(data.Comment)) await writer.WriteAttributeStringAsync(null, "Comment", null, data?.Comment);




        if (data.Properties != null) await DataProperties.CreateProperties(writer, data.Properties);

        if (data.Variables != null) await DataVariable.CreateVariablesAsync(writer, data?.Variables);

        if (data.GsDocSignatures != null) await DataGsDocSignatures.CreateGsDocSignaturesAsync(writer, data?.GsDocSignatures);
        if (data.RegionalK != null) await DataRegionalK.CreateRegionalKAsync(writer, data?.RegionalK);
        if (data.TerZoneK != null) await DataTerZoneK.CreateTerZoneKAsync(writer, data?.TerZoneK);
        if (data.Koefficients != null) await DataKoefficients.CreateKoefficientsAsync(writer, data?.Koefficients);
        if (data.WinterCatalog != null) await DataWinterCatalog.CreateWinterCatalogAsync(writer, data?.WinterCatalog);
        if (data.RegionInfo != null) await DataRegionInfo.CreateRegionInfoAsync(writer, data?.RegionInfo);
        if (data.FRSN_Info != null) await DataFRSN_Info.CreateFRSN_InfoAsync(writer, data?.FRSN_Info);
        if (data.Parameters != null) await DataParameters.CreateParametersAsync(writer, data?.Parameters);
        if (data.Indexes != null) await DataIndexes.CreateIndexesAsync(writer, data?.Indexes);
        if (data.AddZatrats != null) await DataAddZatrats.CreateAddZatratsAsync(writer, data?.AddZatrats);
        if (data.OsInfo != null) await DataOsInfo.CreateOsInfoAsync(writer, data?.OsInfo);
        if (data.CennikAutoLoad != null) await DataCennikAutoLoad.CreateCennikAutoLoadAsync(writer, data?.CennikAutoLoad);


        if (data.VidRab_Catalog != null) await DataVidRab_Catalog.CreateVidRab_CatalogAsync(writer, data?.VidRab_Catalog);




        if (data.Chapters != null) await DataChapter.CreateChaptersAsync(writer, data?.Chapters);




        if (data.ReportOptions != null) await DataReportOptions.CreateReportOptionsAsync(writer, data.ReportOptions);



        await writer.WriteEndElementAsync();


    }
}
