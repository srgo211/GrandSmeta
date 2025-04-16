using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataOsInfo
{
    internal static async Task CreateOsInfoAsync(XmlWriter writer, OsInfo data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "OsInfo", null);
        if (!String.IsNullOrWhiteSpace(data.OSChapter)) await writer.WriteAttributeStringAsync(null, "OSChapter", null, data.OSChapter);
        if (!String.IsNullOrWhiteSpace(data.LinkType)) await writer.WriteAttributeStringAsync(null, "LinkType", null, data.LinkType);
        if (data.CCChapter != null) await CreateCCChapterAsync(writer, data.CCChapter);
        await writer.WriteEndElementAsync();
    }

    internal static async Task CreateCCChapterAsync(XmlWriter writer, ICollection<CCChapter> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (CCChapter? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "CCChapter", null);
            if (!String.IsNullOrWhiteSpace(data.Cons)) await writer.WriteAttributeStringAsync(null, "Cons", null, data.Cons);
            if (!String.IsNullOrWhiteSpace(data.Rec)) await writer.WriteAttributeStringAsync(null, "Rec", null, data.Rec);
            if (!String.IsNullOrWhiteSpace(data.Road)) await writer.WriteAttributeStringAsync(null, "Road", null, data.Road);
            await writer.WriteEndElementAsync();

        }
    }
}
