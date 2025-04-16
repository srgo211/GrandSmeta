using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataWinterCatalog
{
    internal static async Task CreateWinterCatalogAsync(XmlWriter writer, WinterCatalog data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "WinterCatalog", null);

        if (!String.IsNullOrWhiteSpace(data.WinterMode)) await writer.WriteAttributeStringAsync(null, "WinterMode", null, data.WinterMode);
        if (!String.IsNullOrWhiteSpace(data.WinterLinkMode)) await writer.WriteAttributeStringAsync(null, "WinterLinkMode", null, data.WinterLinkMode);
        if (data.CommonWinterK != null) await CreateCommonWinterKAsync(writer, data.CommonWinterK);

        await writer.WriteEndElementAsync();
    }
    static async Task CreateCommonWinterKAsync(XmlWriter writer, ICollection<CommonWinterK> datas)
    {
        await writer.WriteStartElementAsync(null, "CommonWinterK", null);
        await writer.WriteEndElementAsync();
    }
}
