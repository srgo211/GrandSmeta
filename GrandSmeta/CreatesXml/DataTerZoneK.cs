using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataTerZoneK
{
    internal async static Task CreateTerZoneKAsync(XmlWriter writer, TerZoneK data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "TerZoneK", null);
        if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
        if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
        await writer.WriteEndElementAsync();
    }
}
