using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataCennikAutoLoad
{
    internal static async Task CreateCennikAutoLoadAsync(XmlWriter writer, CennikAutoLoad? data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "CennikAutoLoad", null);
        if (!string.IsNullOrWhiteSpace(data.Enabled)) await writer.WriteAttributeStringAsync(null, "Enabled", null, data.Enabled);
        if (!string.IsNullOrWhiteSpace(data.MatchFields)) await writer.WriteAttributeStringAsync(null, "MatchFields", null, data.MatchFields);
        if (!string.IsNullOrWhiteSpace(data.Groups)) await writer.WriteAttributeStringAsync(null, "Groups", null, data.Groups);
        if (!string.IsNullOrWhiteSpace(data.SubGroups)) await writer.WriteAttributeStringAsync(null, "SubGroups", null, data.SubGroups);
        if (!string.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);

        if (data.DocLink != null) await CreateDocLinkAsync(writer, data.DocLink);
        await writer.WriteEndElementAsync();
    }


    internal static async Task CreateDocLinkAsync(XmlWriter writer, DocLink data)
    {
        if (data is null)
        {
            await writer.WriteStartElementAsync(null, "DocLink", null);
            await writer.WriteEndElementAsync();
            return;
        }

        await writer.WriteStartElementAsync(null, "DocLink", null);
        if (!string.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
        if (!string.IsNullOrWhiteSpace(data.Link)) await writer.WriteAttributeStringAsync(null, "Link", null, data.Link);
        if (!string.IsNullOrWhiteSpace(data.Comment)) await writer.WriteAttributeStringAsync(null, "Comment", null, data.Comment);
        await writer.WriteEndElementAsync();


    }
    internal static async Task CreateDocLinkAsync(XmlWriter writer, ICollection<DocLink> datas)
    {
        if (datas is null || !datas.Any())
        {
            await writer.WriteStartElementAsync(null, "DocLink", null);
            await writer.WriteEndElementAsync();
            return;
        }
        foreach (DocLink? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "DocLink", null);
            if (!string.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!string.IsNullOrWhiteSpace(data.Link)) await writer.WriteAttributeStringAsync(null, "Link", null, data.Link);
            if (!string.IsNullOrWhiteSpace(data.Comment)) await writer.WriteAttributeStringAsync(null, "Comment", null, data.Comment);
            await writer.WriteEndElementAsync();

        }
    }
}
