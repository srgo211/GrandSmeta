using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;
public class DataKoefficients
{

    internal static async Task CreateKoefficientsAsync(XmlWriter writer, Koefficients datas)
    {
        if (datas is null) return;
        await writer.WriteStartElementAsync(null, "Koefficients", null);
        await CreateK(writer, datas.K);
        await writer.WriteEndElementAsync();
    }

    private static async Task CreateK(XmlWriter writer, ICollection<K> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (K data in datas)
        {
            await writer.WriteStartElementAsync(null, "K", null);

            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
            if (!String.IsNullOrWhiteSpace(data.Level)) await writer.WriteAttributeStringAsync(null, "Level", null, data.Level);
            if (!String.IsNullOrWhiteSpace(data.Code)) await writer.WriteAttributeStringAsync(null, "Code", null, data.Code);
            if (!String.IsNullOrWhiteSpace(data.Value_PZ)) await writer.WriteAttributeStringAsync(null, "Value_PZ", null, data.Value_PZ);
            if (!String.IsNullOrWhiteSpace(data.Value_OZ)) await writer.WriteAttributeStringAsync(null, "Value_OZ", null, data.Value_OZ);
            if (!String.IsNullOrWhiteSpace(data.Value_EM)) await writer.WriteAttributeStringAsync(null, "Value_EM", null, data.Value_EM);
            if (!String.IsNullOrWhiteSpace(data.Value_MT)) await writer.WriteAttributeStringAsync(null, "Value_MT", null, data.Value_MT);
            if (!String.IsNullOrWhiteSpace(data.Value_ZM)) await writer.WriteAttributeStringAsync(null, "Value_ZM", null, data.Value_ZM);
            if (!String.IsNullOrWhiteSpace(data.AllVidRabs)) await writer.WriteAttributeStringAsync(null, "AllVidRabs", null, data.AllVidRabs);
            if (!String.IsNullOrWhiteSpace(data.VrsLinks)) await writer.WriteAttributeStringAsync(null, "VrsLinks", null, data.VrsLinks);
            if (!String.IsNullOrWhiteSpace(data.Formula)) await writer.WriteAttributeStringAsync(null, "Formula", null, data.Formula);
            if (!String.IsNullOrWhiteSpace(data.Kind)) await writer.WriteAttributeStringAsync(null, "Kind", null, data.Kind);
            if (!String.IsNullOrWhiteSpace(data.AllChapters)) await writer.WriteAttributeStringAsync(null, "AllChapters", null, data.AllChapters);
            if (!String.IsNullOrWhiteSpace(data.VrGroupsLinks)) await writer.WriteAttributeStringAsync(null, "VrGroupsLinks", null, data.VrGroupsLinks);
            if (!String.IsNullOrWhiteSpace(data.ChaptersLinks)) await writer.WriteAttributeStringAsync(null, "ChaptersLinks", null, data.ChaptersLinks);


            await writer.WriteEndElementAsync();
        }
    }
}