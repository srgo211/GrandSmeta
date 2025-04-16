using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;
public class DataResources
{

    internal static async Task CreateResources(XmlWriter writer, Resources datas)
    {
        if (datas is null) return;


        await writer.WriteStartElementAsync(null, "Resources", null);

        await CreateTzr(writer, datas.Tzr);
        await CreateTzm(writer, datas.Tzm);
        await CreateMch(writer, datas.Mch);
        await CreateMat(writer, datas.Mat);

        await writer.WriteEndElementAsync();
    }

    private static async Task CreateTzr(XmlWriter writer, ICollection<Tzr> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Tzr data in datas)
        {

            await writer.WriteStartElementAsync(null, "Tzr", null);

            if (!String.IsNullOrWhiteSpace(data.WorkClass)) await writer.WriteAttributeStringAsync(null, "WorkClass", null, data.WorkClass);
            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Code)) await writer.WriteAttributeStringAsync(null, "Code", null, data.Code);
            if (!String.IsNullOrWhiteSpace(data.Units)) await writer.WriteAttributeStringAsync(null, "Units", null, data.Units);
            if (!String.IsNullOrWhiteSpace(data.Quantity)) await writer.WriteAttributeStringAsync(null, "Quantity", null, data.Quantity);
            if (!String.IsNullOrWhiteSpace(data.Attribs)) await writer.WriteAttributeStringAsync(null, "Attribs", null, data.Attribs);
            if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
            if (!String.IsNullOrWhiteSpace(data.Identifier)) await writer.WriteAttributeStringAsync(null, "Identifier", null, data.Identifier);
            if (!String.IsNullOrWhiteSpace(data.IndexCode)) await writer.WriteAttributeStringAsync(null, "IndexCode", null, data.IndexCode);
            if (!String.IsNullOrWhiteSpace(data.Cargo)) await writer.WriteAttributeStringAsync(null, "Cargo", null, data.Cargo);
            if (!String.IsNullOrWhiteSpace(data.Mass)) await writer.WriteAttributeStringAsync(null, "Mass", null, data.Mass);
            if (!String.IsNullOrWhiteSpace(data.GroupId)) await writer.WriteAttributeStringAsync(null, "GroupId", null, data.GroupId);

            if (data.PriceBase != null) await DataPrice.CreatePriceBaseFirst(writer, data.PriceBase);
            if (data.PriceCurr != null) await DataPrice.CreatePriceCurrFirst(writer, data.PriceCurr);

            if (data.Tzm2022 != null) await CreateTzm2022First(writer, data.Tzm2022);


            await writer.WriteEndElementAsync();


        }


    }
    private static async Task CreateTzm(XmlWriter writer, ICollection<Tzm> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Tzm data in datas)
        {

            await writer.WriteStartElementAsync(null, "Tzm", null);

            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Code)) await writer.WriteAttributeStringAsync(null, "Code", null, data.Code);
            if (!String.IsNullOrWhiteSpace(data.Units)) await writer.WriteAttributeStringAsync(null, "Units", null, data.Units);
            if (!String.IsNullOrWhiteSpace(data.Quantity)) await writer.WriteAttributeStringAsync(null, "Quantity", null, data.Quantity);
            if (!String.IsNullOrWhiteSpace(data.Attribs)) await writer.WriteAttributeStringAsync(null, "Attribs", null, data.Attribs);
            if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
            if (!String.IsNullOrWhiteSpace(data.Identifier)) await writer.WriteAttributeStringAsync(null, "Identifier", null, data.Identifier);
            if (!String.IsNullOrWhiteSpace(data.IndexCode)) await writer.WriteAttributeStringAsync(null, "IndexCode", null, data.IndexCode);
            if (!String.IsNullOrWhiteSpace(data.Cargo)) await writer.WriteAttributeStringAsync(null, "Cargo", null, data.Cargo);
            if (!String.IsNullOrWhiteSpace(data.Mass)) await writer.WriteAttributeStringAsync(null, "Mass", null, data.Mass);
            if (!String.IsNullOrWhiteSpace(data.GroupId)) await writer.WriteAttributeStringAsync(null, "GroupId", null, data.GroupId);

            await DataPrice.CreatePriceBaseFirst(writer, data.PriceBase);
            await DataPrice.CreatePriceCurrFirst(writer, data.PriceCurr);
            await CreateTzm2022First(writer, data.Tzm2022);


            await writer.WriteEndElementAsync();
        }


    }
    private static async Task CreateMat(XmlWriter writer, ICollection<Mat> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Mat data in datas)
        {

            await writer.WriteStartElementAsync(null, "Mat", null);



            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Code)) await writer.WriteAttributeStringAsync(null, "Code", null, data.Code);
            if (!String.IsNullOrWhiteSpace(data.Units)) await writer.WriteAttributeStringAsync(null, "Units", null, data.Units);
            if (!String.IsNullOrWhiteSpace(data.Quantity)) await writer.WriteAttributeStringAsync(null, "Quantity", null, data.Quantity);
            if (!String.IsNullOrWhiteSpace(data.Attribs)) await writer.WriteAttributeStringAsync(null, "Attribs", null, data.Attribs);
            if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
            if (!String.IsNullOrWhiteSpace(data.Identifier)) await writer.WriteAttributeStringAsync(null, "Identifier", null, data.Identifier);
            if (!String.IsNullOrWhiteSpace(data.IndexCode)) await writer.WriteAttributeStringAsync(null, "IndexCode", null, data.IndexCode);
            if (!String.IsNullOrWhiteSpace(data.Cargo)) await writer.WriteAttributeStringAsync(null, "Cargo", null, data.Cargo);
            if (!String.IsNullOrWhiteSpace(data.Mass)) await writer.WriteAttributeStringAsync(null, "Mass", null, data.Mass);
            if (!String.IsNullOrWhiteSpace(data.GroupId)) await writer.WriteAttributeStringAsync(null, "GroupId", null, data.GroupId);
            await DataPrice.CreatePriceBaseFirst(writer, data.PriceBase);
            await DataPrice.CreatePriceCurrFirst(writer, data.PriceCurr);
            await CreateTzm2022First(writer, data.Tzm2022);


            await DataKoefficients.CreateKoefficientsAsync(writer, data.Koefficients);

            await writer.WriteEndElementAsync();
        }


    }
    private static async Task CreateMch(XmlWriter writer, ICollection<Mch> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Mch data in datas)
        {

            await writer.WriteStartElementAsync(null, "Mch", null);

            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Code)) await writer.WriteAttributeStringAsync(null, "Code", null, data.Code);
            if (!String.IsNullOrWhiteSpace(data.Units)) await writer.WriteAttributeStringAsync(null, "Units", null, data.Units);
            if (!String.IsNullOrWhiteSpace(data.Quantity)) await writer.WriteAttributeStringAsync(null, "Quantity", null, data.Quantity);
            if (!String.IsNullOrWhiteSpace(data.Attribs)) await writer.WriteAttributeStringAsync(null, "Attribs", null, data.Attribs);
            if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
            if (!String.IsNullOrWhiteSpace(data.Identifier)) await writer.WriteAttributeStringAsync(null, "Identifier", null, data.Identifier);
            if (!String.IsNullOrWhiteSpace(data.IndexCode)) await writer.WriteAttributeStringAsync(null, "IndexCode", null, data.IndexCode);
            if (!String.IsNullOrWhiteSpace(data.Cargo)) await writer.WriteAttributeStringAsync(null, "Cargo", null, data.Cargo);
            if (!String.IsNullOrWhiteSpace(data.Mass)) await writer.WriteAttributeStringAsync(null, "Mass", null, data.Mass);
            if (!String.IsNullOrWhiteSpace(data.GroupId)) await writer.WriteAttributeStringAsync(null, "GroupId", null, data.GroupId);

            await DataPrice.CreatePriceBaseFirst(writer, data.PriceBase);
            await DataPrice.CreatePriceCurrFirst(writer, data.PriceCurr);
            await CreateTzm2022First(writer, data.Tzm2022);


            await writer.WriteEndElementAsync();
        }
    }

    private static async Task CreateTzm2022(XmlWriter writer, ICollection<Tzm2022> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Tzm2022 data in datas)
        {
            await writer.WriteStartElementAsync(null, "Tzm2022", null);

            if (!String.IsNullOrWhiteSpace(data.WorkClass)) await writer.WriteAttributeStringAsync(null, "WorkClass", null, data.WorkClass);
            if (!String.IsNullOrWhiteSpace(data.Quantity)) await writer.WriteAttributeStringAsync(null, "Quantity", null, data.Quantity);
            if (!String.IsNullOrWhiteSpace(data.Price)) await writer.WriteAttributeStringAsync(null, "Price", null, data.Price);

            await writer.WriteEndElementAsync();
        }
    }

    internal static async Task CreateTzm2022First(XmlWriter writer, Tzm2022 data)
    {
        if (data is null) return;

        await writer.WriteStartElementAsync(null, "Tzm2022", null);

        if (!String.IsNullOrWhiteSpace(data.WorkClass)) await writer.WriteAttributeStringAsync(null, "WorkClass", null, data.WorkClass);
        if (!String.IsNullOrWhiteSpace(data.Quantity)) await writer.WriteAttributeStringAsync(null, "Quantity", null, data.Quantity);
        if (!String.IsNullOrWhiteSpace(data.Price)) await writer.WriteAttributeStringAsync(null, "Price", null, data.Price);

        await writer.WriteEndElementAsync();

    }
}
