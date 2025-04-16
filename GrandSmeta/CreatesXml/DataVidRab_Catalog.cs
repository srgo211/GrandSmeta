using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataVidRab_Catalog
{
    internal static async Task CreateVidRab_CatalogAsync(XmlWriter writer, VidRab_Catalog data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "VidRab_Catalog", null);
        if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
        if (data.Vids_Rab != null) await CreateVids_RabAsync(writer, data.Vids_Rab);
        await writer.WriteEndElementAsync();
    }



    internal static async Task CreateVids_RabAsync(XmlWriter writer, ICollection<Vids_Rab> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Vids_Rab? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "Vids_Rab", null);
            if (!String.IsNullOrWhiteSpace(data.Type)) await writer.WriteAttributeStringAsync(null, "Type", null, data.Type);
            if (!String.IsNullOrWhiteSpace(data.CatFile)) await writer.WriteAttributeStringAsync(null, "CatFile", null, data.CatFile);
            if (!String.IsNullOrWhiteSpace(data.NrspFile)) await writer.WriteAttributeStringAsync(null, "NrspFile", null, data.NrspFile);
            if (!String.IsNullOrWhiteSpace(data.KfsFiles)) await writer.WriteAttributeStringAsync(null, "KfsFiles", null, data.KfsFiles);
            if (data.VidRab_Group != null) await CreateVidRab_GroupAsync(writer, data.VidRab_Group);
            await writer.WriteEndElementAsync();
        }
    }

    internal static async Task CreateVidRab_GroupAsync(XmlWriter writer, ICollection<VidRab_Group> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (VidRab_Group? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "VidRab_Group", null);
            if (!String.IsNullOrWhiteSpace(data.ID)) await writer.WriteAttributeStringAsync(null, "ID", null, data.ID);
            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.IndexCode)) await writer.WriteAttributeStringAsync(null, "IndexCode", null, data.IndexCode);
            if (data.Vid_Rab != null) await CreateVid_RabAsync(writer, data.Vid_Rab);
            await writer.WriteEndElementAsync();

        }
    }



    internal static async Task CreateVid_RabAsync(XmlWriter writer, ICollection<Vid_Rab> datas)
    {

        if (datas is null || !datas.Any()) return;
        foreach (Vid_Rab? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "Vid_Rab", null);
            if (!String.IsNullOrWhiteSpace(data.ID)) await writer.WriteAttributeStringAsync(null, "ID", null, data.ID);
            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Nacl)) await writer.WriteAttributeStringAsync(null, "Nacl", null, data.Nacl);
            if (!String.IsNullOrWhiteSpace(data.Plan)) await writer.WriteAttributeStringAsync(null, "Plan", null, data.Plan);
            if (!String.IsNullOrWhiteSpace(data.Category)) await writer.WriteAttributeStringAsync(null, "Category", null, data.Category);
            if (!String.IsNullOrWhiteSpace(data.NrCode)) await writer.WriteAttributeStringAsync(null, "NrCode", null, data.NrCode);
            if (!String.IsNullOrWhiteSpace(data.SpCode)) await writer.WriteAttributeStringAsync(null, "SpCode", null, data.SpCode);
            if (!String.IsNullOrWhiteSpace(data.NaclMask)) await writer.WriteAttributeStringAsync(null, "NaclMask", null, data.NaclMask);
            if (!String.IsNullOrWhiteSpace(data.PlanMask)) await writer.WriteAttributeStringAsync(null, "PlanMask", null, data.PlanMask);
            if (!String.IsNullOrWhiteSpace(data.OsColumn)) await writer.WriteAttributeStringAsync(null, "OsColumn", null, data.OsColumn);
            if (!String.IsNullOrWhiteSpace(data.NaclCurr)) await writer.WriteAttributeStringAsync(null, "NaclCurr", null, data.NaclCurr);
            if (!String.IsNullOrWhiteSpace(data.PlanCurr)) await writer.WriteAttributeStringAsync(null, "PlanCurr", null, data.PlanCurr);
            if (!String.IsNullOrWhiteSpace(data.NKI)) await writer.WriteAttributeStringAsync(null, "NKI", null, data.NKI);
            if (!String.IsNullOrWhiteSpace(data.PKI)) await writer.WriteAttributeStringAsync(null, "PKI", null, data.PKI);
            if (!String.IsNullOrWhiteSpace(data.NKR)) await writer.WriteAttributeStringAsync(null, "NKR", null, data.NKR);
            if (!String.IsNullOrWhiteSpace(data.PKR)) await writer.WriteAttributeStringAsync(null, "PKR", null, data.PKR);
            if (!String.IsNullOrWhiteSpace(data.IndexCode)) await writer.WriteAttributeStringAsync(null, "IndexCode", null, data.IndexCode);
            if (!String.IsNullOrWhiteSpace(data.ResGroup)) await writer.WriteAttributeStringAsync(null, "ResGroup", null, data.ResGroup);
            if (!String.IsNullOrWhiteSpace(data.PNB)) await writer.WriteAttributeStringAsync(null, "PNB", null, data.PNB);
            if (!String.IsNullOrWhiteSpace(data.NKB)) await writer.WriteAttributeStringAsync(null, "NKB", null, data.NKB);
            if (!String.IsNullOrWhiteSpace(data.NrspCode)) await writer.WriteAttributeStringAsync(null, "NrspCode", null, data.NrspCode);
            await writer.WriteEndElementAsync();

        }

    }



}
