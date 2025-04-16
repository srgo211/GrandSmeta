using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataAddZatrats
{
    internal static async Task CreateAddZatratsAsync(XmlWriter writer, AddZatrats data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "AddZatrats", null);
        if (data.AddZatrGlava != null) await CreateAddZatratsAsync(writer, data.AddZatrGlava);
        await writer.WriteEndElementAsync();
    }

    internal static async Task CreateAddZatratsAsync(XmlWriter writer, ICollection<AddZatrGlava> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (AddZatrGlava? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "AddZatrGlava", null);
            if (!String.IsNullOrWhiteSpace(data.Glava)) await writer.WriteAttributeStringAsync(null, "Glava", null, data.Glava);
            if (data.AddZatr != null) await CreateAddZatratsAsync(writer, data.AddZatr);
            await writer.WriteEndElementAsync();
        }
    }

    internal static async Task CreateAddZatratsAsync(XmlWriter writer, ICollection<AddZatr> datas)
    {

        if (datas is null || !datas.Any()) return;
        foreach (AddZatr? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "AddZatr", null);
            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
            if (!String.IsNullOrWhiteSpace(data.Identifier)) await writer.WriteAttributeStringAsync(null, "Identifier", null, data.Identifier);
            if (!String.IsNullOrWhiteSpace(data.Formula)) await writer.WriteAttributeStringAsync(null, "Formula", null, data.Formula);
            if (!String.IsNullOrWhiteSpace(data.Value)) await writer.WriteAttributeStringAsync(null, "Value", null, data.Value);
            if (!String.IsNullOrWhiteSpace(data.Level)) await writer.WriteAttributeStringAsync(null, "Level", null, data.Level);
            await writer.WriteEndElementAsync();

        }
    }


}