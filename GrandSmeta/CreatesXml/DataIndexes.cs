using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataIndexes
{
    internal static async Task CreateIndexesAsync(XmlWriter writer, Indexes data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "Indexes", null);
        if (!String.IsNullOrWhiteSpace(data.IndexesMode)) await writer.WriteAttributeStringAsync(null, "IndexesMode", null, data.IndexesMode);
        if (!String.IsNullOrWhiteSpace(data.IndexesLinkMode)) await writer.WriteAttributeStringAsync(null, "IndexesLinkMode", null, data.IndexesLinkMode);
        if (data.CategoryIndexes != null) await CreateCategoryIndexesAsync(writer, data.CategoryIndexes);
        await writer.WriteEndElementAsync();
    }


    internal static async Task CreateCategoryIndexesAsync(XmlWriter writer, ICollection<CategoryIndexes> datas)
    {
        if (datas is null || !datas.Any()) return;

        foreach (CategoryIndexes? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "CategoryIndexes", null);
            if (!String.IsNullOrWhiteSpace(data.Construction)) await writer.WriteAttributeStringAsync(null, "Construction", null, data.Construction);
            if (!String.IsNullOrWhiteSpace(data.ConstrTransportation)) await writer.WriteAttributeStringAsync(null, "ConstrTransportation", null, data.ConstrTransportation);
            if (!String.IsNullOrWhiteSpace(data.Transportation)) await writer.WriteAttributeStringAsync(null, "Transportation", null, data.Transportation);
            if (!String.IsNullOrWhiteSpace(data.ConstrRelated)) await writer.WriteAttributeStringAsync(null, "ConstrRelated", null, data.ConstrRelated);
            if (!String.IsNullOrWhiteSpace(data.Mounting)) await writer.WriteAttributeStringAsync(null, "Mounting", null, data.Mounting);
            if (!String.IsNullOrWhiteSpace(data.MountingRelated)) await writer.WriteAttributeStringAsync(null, "MountingRelated", null, data.MountingRelated);
            await writer.WriteEndElementAsync();

        }

    }
}
