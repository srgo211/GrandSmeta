using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataProperties
{
    public static async Task CreateProperties(XmlWriter writer, Properties data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "Properties", null);
        if (!String.IsNullOrWhiteSpace(data.RegNum)) await writer.WriteAttributeStringAsync(null, "RegNum", null, data.RegNum);
        if (!String.IsNullOrWhiteSpace(data.Description)) await writer.WriteAttributeStringAsync(null, "Description", null, data.Description);
        if (!String.IsNullOrWhiteSpace(data.Stage)) await writer.WriteAttributeStringAsync(null, "Stage", null, data.Stage);
        if (!String.IsNullOrWhiteSpace(data.Object)) await writer.WriteAttributeStringAsync(null, "Object", null, data.Object);
        if (!String.IsNullOrWhiteSpace(data.Constr)) await writer.WriteAttributeStringAsync(null, "Constr", null, data.Constr);
        if (!String.IsNullOrWhiteSpace(data.LocNum)) await writer.WriteAttributeStringAsync(null, "LocNum", null, data.LocNum);
        if (!String.IsNullOrWhiteSpace(data.Comment)) await writer.WriteAttributeStringAsync(null, "Comment", null, data.Comment);
        await writer.WriteEndElementAsync();
    }
}
