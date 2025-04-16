using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataRegionInfo
{
    internal static async Task CreateRegionInfoAsync(XmlWriter writer, RegionInfo data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "RegionInfo", null);
        if (!String.IsNullOrWhiteSpace(data.RegionName)) await writer.WriteAttributeStringAsync(null, "RegionName", null, data.RegionName);
        if (!String.IsNullOrWhiteSpace(data.RegionID)) await writer.WriteAttributeStringAsync(null, "RegionID", null, data.RegionID);
        if (!String.IsNullOrWhiteSpace(data.Zone01ID)) await writer.WriteAttributeStringAsync(null, "Zone01ID", null, data.Zone01ID);
        if (!String.IsNullOrWhiteSpace(data.Zone01Name)) await writer.WriteAttributeStringAsync(null, "Zone01Name", null, data.Zone01Name);
        if (!String.IsNullOrWhiteSpace(data.Zone84ID)) await writer.WriteAttributeStringAsync(null, "Zone84ID", null, data.Zone84ID);
        if (!String.IsNullOrWhiteSpace(data.Zone84Name)) await writer.WriteAttributeStringAsync(null, "Zone84Name", null, data.Zone84Name);
        await writer.WriteEndElementAsync();
    }
}
