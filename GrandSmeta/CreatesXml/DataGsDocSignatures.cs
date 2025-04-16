using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataGsDocSignatures
{
    internal async static Task CreateGsDocSignaturesAsync(XmlWriter writer, GsDocSignatures data)
    {

        if (data is null) return;
        await writer.WriteStartElementAsync(null, "GsDocSignatures", null);
        if (data.Item != null) await CreateItemAsync(writer, data.Item);
        await writer.WriteEndElementAsync();
    }


    internal async static Task CreateItemAsync(XmlWriter writer, ICollection<Item> datas)
    {
        if (datas is null || !datas.Any()) return;



        foreach (Item data in datas)
        {
            await writer.WriteStartElementAsync(null, "Item", null);
            if (!String.IsNullOrWhiteSpace(data.ID)) await writer.WriteAttributeStringAsync(null, "ID", null, data.ID);
            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Value)) await writer.WriteAttributeStringAsync(null, "Value", null, data.Value);
            await writer.WriteEndElementAsync();
        }

    }
}
