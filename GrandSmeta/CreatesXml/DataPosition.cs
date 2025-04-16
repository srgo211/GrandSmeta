using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataPosition
{

    public static async Task CreatePosition(XmlWriter writer, ICollection<Position> datas)
    {
        if (datas is null || !datas.Any()) return;
        int testCount = 0;
        foreach (Position data in datas)
        {
            await writer.WriteStartElementAsync(null, "Position", null);

            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!String.IsNullOrWhiteSpace(data.Number)) await writer.WriteAttributeStringAsync(null, "Number", null, data.Number);
            if (!String.IsNullOrWhiteSpace(data.Code)) await writer.WriteAttributeStringAsync(null, "Code", null, data.Code);
            if (!String.IsNullOrWhiteSpace(data.ItemFlags)) await writer.WriteAttributeStringAsync(null, "ItemFlags", null, data.ItemFlags);
            if (!String.IsNullOrWhiteSpace(data.Units)) await writer.WriteAttributeStringAsync(null, "Units", null, data.Units);
            if (!String.IsNullOrWhiteSpace(data.SysID)) await writer.WriteAttributeStringAsync(null, "SysID", null, data.SysID);
            if (!String.IsNullOrWhiteSpace(data.PriceLevel)) await writer.WriteAttributeStringAsync(null, "PriceLevel", null, data.PriceLevel);
            if (!String.IsNullOrWhiteSpace(data.Quantity)) await writer.WriteAttributeStringAsync(null, "Quantity", null, data.Quantity);
            if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
            if (!String.IsNullOrWhiteSpace(data.PzSync)) await writer.WriteAttributeStringAsync(null, "PzSync", null, data.PzSync);
            if (!String.IsNullOrWhiteSpace(data.Vr2001)) await writer.WriteAttributeStringAsync(null, "Vr2001", null, data.Vr2001);
            if (!String.IsNullOrWhiteSpace(data.Mass)) await writer.WriteAttributeStringAsync(null, "Mass", null, data.Mass);
            if (!String.IsNullOrWhiteSpace(data.UserComment1)) await writer.WriteAttributeStringAsync(null, "UserComment1", null, data.UserComment1);
            if (!String.IsNullOrWhiteSpace(data.UserComment2)) await writer.WriteAttributeStringAsync(null, "UserComment2", null, data.UserComment2);
            if (!String.IsNullOrWhiteSpace(data.ColorIndex)) await writer.WriteAttributeStringAsync(null, "ColorIndex", null, data.ColorIndex);
            if (!String.IsNullOrWhiteSpace(data.Identifier)) await writer.WriteAttributeStringAsync(null, "Identifier", null, data.Identifier);
            if (!String.IsNullOrWhiteSpace(data.IndexCode)) await writer.WriteAttributeStringAsync(null, "IndexCode", null, data.IndexCode);
            if (!String.IsNullOrWhiteSpace(data.Cargo)) await writer.WriteAttributeStringAsync(null, "Cargo", null, data.Cargo);
            if (!String.IsNullOrWhiteSpace(data.DBComment)) await writer.WriteAttributeStringAsync(null, "DBComment", null, data.DBComment);
            if (!String.IsNullOrWhiteSpace(data.DBFlags)) await writer.WriteAttributeStringAsync(null, "DBFlags", null, data.DBFlags);
            if (!String.IsNullOrWhiteSpace(data.SlaveRow)) await writer.WriteAttributeStringAsync(null, "SlaveRow", null, data.SlaveRow);
            if (!String.IsNullOrWhiteSpace(data.Comment)) await writer.WriteAttributeStringAsync(null, "Comment", null, data.Comment);
            if (!String.IsNullOrWhiteSpace(data.Bookmark)) await writer.WriteAttributeStringAsync(null, "Bookmark", null, data.Bookmark);
            if (!String.IsNullOrWhiteSpace(data.NKB)) await writer.WriteAttributeStringAsync(null, "NKB", null, data.NKB);
            if (!String.IsNullOrWhiteSpace(data.NKI)) await writer.WriteAttributeStringAsync(null, "NKI", null, data.NKI);
            if (!String.IsNullOrWhiteSpace(data.NKR)) await writer.WriteAttributeStringAsync(null, "NKR", null, data.NKR);
            if (!String.IsNullOrWhiteSpace(data.PNB)) await writer.WriteAttributeStringAsync(null, "PNB", null, data.PNB);
            if (!String.IsNullOrWhiteSpace(data.PKI)) await writer.WriteAttributeStringAsync(null, "PKI", null, data.PKI);
            if (!String.IsNullOrWhiteSpace(data.PKR)) await writer.WriteAttributeStringAsync(null, "PKR", null, data.PKR);
            if (!String.IsNullOrWhiteSpace(data.BaseCalcMode)) await writer.WriteAttributeStringAsync(null, "BaseCalcMode", null, data.BaseCalcMode);
            if (!String.IsNullOrWhiteSpace(data.WinterK)) await writer.WriteAttributeStringAsync(null, "WinterK", null, data.WinterK);

            if (!String.IsNullOrWhiteSpace(data.AuxMatCode)) await writer.WriteAttributeStringAsync(null, "AuxMatCode", null, data.AuxMatCode);
            if (!String.IsNullOrWhiteSpace(data.AuxMat)) await writer.WriteAttributeStringAsync(null, "AuxMat", null, data.AuxMat);


            if (data.Resources != null) await DataResources.CreateResources(writer, data.Resources);
            if (data.Koefficients != null) await DataKoefficients.CreateKoefficientsAsync(writer, data.Koefficients);
            if (data.PriceBase != null) await DataPrice.CreatePriceBaseFirst(writer, data.PriceBase);
            if (data.PriceCurr != null) await DataPrice.CreatePriceCurrFirst(writer, data.PriceCurr);
            if (data.Tzm2022 != null) await DataResources.CreateTzm2022First(writer, data.Tzm2022);


            if (data != null) await CreateWorksList(writer, data.WorksList);
            if (data != null) await CreateCustomNPCurr(writer, data.CustomNPCurr);
            if (data != null) await CreateQuantityFirst(writer, data.Quantitys);






            await writer.WriteEndElementAsync();


            testCount++;
        }
    }







    private static async Task CreateWorksList(XmlWriter writer, WorksList datas)
    {
        if (datas is null) return;

        await writer.WriteStartElementAsync(null, "WorksList", null);

        await CreateWork(writer, datas.Work);

        await writer.WriteEndElementAsync();


    }
    private static async Task CreateWork(XmlWriter writer, ICollection<Work> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (Work data in datas)
        {
            await writer.WriteStartElementAsync(null, "Work", null);
            if (!String.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            await writer.WriteEndElementAsync();
        }
    }

    private static async Task CreateCustomNPCurr(XmlWriter writer, CustomNPCurr datas)
    {
        if (datas is null) return;
        await writer.WriteStartElementAsync(null, "CustomNPCurr", null);

        if (!String.IsNullOrWhiteSpace(datas.Nacl)) await writer.WriteAttributeStringAsync(null, "Nacl", null, datas.Nacl);
        if (!String.IsNullOrWhiteSpace(datas.NaclMask)) await writer.WriteAttributeStringAsync(null, "NaclMask", null, datas.NaclMask);
        if (!String.IsNullOrWhiteSpace(datas.Plan)) await writer.WriteAttributeStringAsync(null, "Plan", null, datas.Plan);
        if (!String.IsNullOrWhiteSpace(datas.PlanMask)) await writer.WriteAttributeStringAsync(null, "PlanMask", null, datas.PlanMask);

        await writer.WriteEndElementAsync();


    }
    private static async Task CreateQuantityFirst(XmlWriter writer, Quantity data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "Quantity", null);

        if (!String.IsNullOrWhiteSpace(data.CalcRows)) await writer.WriteAttributeStringAsync(null, "CalcRows", null, data.CalcRows);
        if (!String.IsNullOrWhiteSpace(data.Fx)) await writer.WriteAttributeStringAsync(null, "Fx", null, data.Fx);
        if (!String.IsNullOrWhiteSpace(data.Precision)) await writer.WriteAttributeStringAsync(null, "Precision", null, data.Precision);
        if (!String.IsNullOrWhiteSpace(data.KUnit)) await writer.WriteAttributeStringAsync(null, "KUnit", null, data.KUnit);
        if (!String.IsNullOrWhiteSpace(data.KMult)) await writer.WriteAttributeStringAsync(null, "KMult", null, data.KMult);
        if (!String.IsNullOrWhiteSpace(data.Result)) await writer.WriteAttributeStringAsync(null, "Result", null, data.Result);
        if (!String.IsNullOrWhiteSpace(data.RoundDirection)) await writer.WriteAttributeStringAsync(null, "RoundDirection", null, data.RoundDirection);

        await writer.WriteEndElementAsync();


    }


    private static async Task Create(XmlWriter writer, object[] datas)
    {
        if (datas is null || datas.Length == 0) return;
        foreach (object data in datas)
        {
            await writer.WriteStartElementAsync(null, "", null);

            await writer.WriteEndElementAsync();
        }


        return;
    }
}