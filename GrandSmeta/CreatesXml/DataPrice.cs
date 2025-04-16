using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;
public class DataPrice
{
    internal static async Task CreatePriceBase(XmlWriter writer, ICollection<Price> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Price data in datas)
        {
            await CreatePriceBaseFirst(writer, data);
        }

    }
    internal static async Task CreatePriceBaseFirst(XmlWriter writer, Price data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "PriceBase", null);

        if (!String.IsNullOrWhiteSpace(data.Value)) await writer.WriteAttributeStringAsync(null, "Value", null, data.Value);
        if (!String.IsNullOrWhiteSpace(data.PZ)) await writer.WriteAttributeStringAsync(null, "PZ", null, data.PZ);
        if (!String.IsNullOrWhiteSpace(data.OZ)) await writer.WriteAttributeStringAsync(null, "OZ", null, data.OZ);
        if (!String.IsNullOrWhiteSpace(data.EM)) await writer.WriteAttributeStringAsync(null, "EM", null, data.EM);
        if (!String.IsNullOrWhiteSpace(data.ZM)) await writer.WriteAttributeStringAsync(null, "ZM", null, data.ZM);
        if (!String.IsNullOrWhiteSpace(data.MT)) await writer.WriteAttributeStringAsync(null, "MT", null, data.MT);
        if (!String.IsNullOrWhiteSpace(data.Comment)) await writer.WriteAttributeStringAsync(null, "Comment", null, data.Comment);

        await writer.WriteEndElementAsync();
    }

    internal static async Task CreatePriceCurr(XmlWriter writer, ICollection<Price> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Price data in datas)
        {
            await CreatePriceCurrFirst(writer, data);
        }

    }
    internal static async Task CreatePriceCurrFirst(XmlWriter writer, Price data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "PriceCurr", null);

        if (!String.IsNullOrWhiteSpace(data.Value)) await writer.WriteAttributeStringAsync(null, "Value", null, data.Value);
        if (!String.IsNullOrWhiteSpace(data.PZ)) await writer.WriteAttributeStringAsync(null, "PZ", null, data.PZ);
        if (!String.IsNullOrWhiteSpace(data.OZ)) await writer.WriteAttributeStringAsync(null, "OZ", null, data.OZ);
        if (!String.IsNullOrWhiteSpace(data.EM)) await writer.WriteAttributeStringAsync(null, "EM", null, data.EM);
        if (!String.IsNullOrWhiteSpace(data.ZM)) await writer.WriteAttributeStringAsync(null, "ZM", null, data.ZM);
        if (!String.IsNullOrWhiteSpace(data.MT)) await writer.WriteAttributeStringAsync(null, "MT", null, data.MT);
        if (!String.IsNullOrWhiteSpace(data.Comment)) await writer.WriteAttributeStringAsync(null, "Comment", null, data.Comment);

        await writer.WriteEndElementAsync();
    }
}