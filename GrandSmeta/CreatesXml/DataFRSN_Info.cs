using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataFRSN_Info
{
    internal static async Task CreateFRSN_InfoAsync(XmlWriter writer, FRSN_Info data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "FRSN_Info", null);
        if (!String.IsNullOrWhiteSpace(data.BaseType)) await writer.WriteAttributeStringAsync(null, "BaseType", null, data.BaseType);
        if (!String.IsNullOrWhiteSpace(data.BaseName)) await writer.WriteAttributeStringAsync(null, "BaseName", null, data.BaseName);
        if (!String.IsNullOrWhiteSpace(data.RegNumber)) await writer.WriteAttributeStringAsync(null, "RegNumber", null, data.RegNumber);
        if (!String.IsNullOrWhiteSpace(data.RegDate)) await writer.WriteAttributeStringAsync(null, "RegDate", null, data.RegDate);
        await writer.WriteEndElementAsync();
    }
}
