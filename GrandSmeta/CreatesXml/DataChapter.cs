using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataChapter
{
    

    internal static async Task CreateChaptersAsync(XmlWriter writer, Chapters chapters)
    {
        if (chapters is null) return;

        ICollection<Chapter>? datas = chapters.Chapter;
        if (datas is null || !datas.Any()) return;
        await writer.WriteStartElementAsync(null, "Chapters", null);

        foreach (Chapter data in datas)
        {
            await writer.WriteStartElementAsync(null, "Chapter", null);


            if (!String.IsNullOrWhiteSpace(data.SysID)) await writer.WriteAttributeStringAsync(null, "SysID", null, data.SysID);
            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.IndexCode)) await writer.WriteAttributeStringAsync(null, "IndexCode", null, data.IndexCode);
            if (!String.IsNullOrWhiteSpace(data.CostPerUnitDescr)) await writer.WriteAttributeStringAsync(null, "CostPerUnitDescr", null, data.CostPerUnitDescr);
            if (!String.IsNullOrWhiteSpace(data.UnitsQty)) await writer.WriteAttributeStringAsync(null, "UnitsQty", null, data.UnitsQty);
            if (!String.IsNullOrWhiteSpace(data.Units)) await writer.WriteAttributeStringAsync(null, "Units", null, data.Units);

            if (data.Position != null) await DataPosition.CreatePosition(writer, data.Position);


            //if(!String.IsNullOrWhiteSpace(data.Header))           await writer.WriteAttributeStringAsync(null, "Header",           null, data.Header);
            //if(!String.IsNullOrWhiteSpace(data.Comment))          await writer.WriteAttributeStringAsync(null, "Comment",          null, data.Comment);
            //if(!String.IsNullOrWhiteSpace(data.Itog))             await writer.WriteAttributeStringAsync(null, "Itog",             null, data.Itog);



            await writer.WriteEndElementAsync();
        }

        await writer.WriteEndElementAsync();
    }
}
