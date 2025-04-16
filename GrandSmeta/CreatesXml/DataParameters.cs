using GrandSmeta.Models;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataParameters
{
    internal static async Task CreateParametersAsync(XmlWriter writer, Parameters data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "Parameters", null);
        if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
        if (!String.IsNullOrWhiteSpace(data.BasePrices)) await writer.WriteAttributeStringAsync(null, "BasePrices", null, data.BasePrices);
        if (!String.IsNullOrWhiteSpace(data.BaseCalcVrs)) await writer.WriteAttributeStringAsync(null, "BaseCalcVrs", null, data.BaseCalcVrs);
        if (!String.IsNullOrWhiteSpace(data.TzDigits)) await writer.WriteAttributeStringAsync(null, "TzDigits", null, data.TzDigits);
        if (!String.IsNullOrWhiteSpace(data.BlockRoundMode)) await writer.WriteAttributeStringAsync(null, "BlockRoundMode", null, data.BlockRoundMode);
        if (!String.IsNullOrWhiteSpace(data.MultKPosCalcMode)) await writer.WriteAttributeStringAsync(null, "MultKPosCalcMode", null, data.MultKPosCalcMode);
        if (!String.IsNullOrWhiteSpace(data.TempZone)) await writer.WriteAttributeStringAsync(null, "TempZone", null, data.TempZone);
        if (!String.IsNullOrWhiteSpace(data.TsnTempZone)) await writer.WriteAttributeStringAsync(null, "TsnTempZone", null, data.TsnTempZone);
        if (!String.IsNullOrWhiteSpace(data.MatDigits)) await writer.WriteAttributeStringAsync(null, "MatDigits", null, data.MatDigits);
        if (!String.IsNullOrWhiteSpace(data.MatRoundMode)) await writer.WriteAttributeStringAsync(null, "MatRoundMode", null, data.MatRoundMode);
        if (!String.IsNullOrWhiteSpace(data.PosKDigits)) await writer.WriteAttributeStringAsync(null, "PosKDigits", null, data.PosKDigits);
        if (!String.IsNullOrWhiteSpace(data.ItogOptions)) await writer.WriteAttributeStringAsync(null, "ItogOptions", null, data.ItogOptions);
        if (!String.IsNullOrWhiteSpace(data.FirstItogItem)) await writer.WriteAttributeStringAsync(null, "FirstItogItem", null, data.FirstItogItem);
        if (!String.IsNullOrWhiteSpace(data.ItogExpandTo)) await writer.WriteAttributeStringAsync(null, "ItogExpandTo", null, data.ItogExpandTo);
        if (!String.IsNullOrWhiteSpace(data.UnitsQty)) await writer.WriteAttributeStringAsync(null, "UnitsQty", null, data.UnitsQty);
        if (!String.IsNullOrWhiteSpace(data.Units)) await writer.WriteAttributeStringAsync(null, "Units", null, data.Units);
        if (!String.IsNullOrWhiteSpace(data.PropsConfigName)) await writer.WriteAttributeStringAsync(null, "PropsConfigName", null, data.PropsConfigName);
        if (!String.IsNullOrWhiteSpace(data.CostPerUnitDescr)) await writer.WriteAttributeStringAsync(null, "CostPerUnitDescr", null, data.CostPerUnitDescr);
        if (!String.IsNullOrWhiteSpace(data.CurrPricesReason)) await writer.WriteAttributeStringAsync(null, "CurrPricesReason", null, data.CurrPricesReason);
        if (!String.IsNullOrWhiteSpace(data.Mode2020Order)) await writer.WriteAttributeStringAsync(null, "Mode2020Order", null, data.Mode2020Order);

        if (data.CommonNK != null) await CreateCommonNKAsync(writer, data.CommonNK);
        if (data.CommonPK != null) await CreateCommonPKAsync(writer, data.CommonPK);
        if (data.Numbering != null) await CreateNumberingAsync(writer, data.Numbering);
        await writer.WriteEndElementAsync();

    }
    internal static async Task CreateCommonNKAsync(XmlWriter writer, ICollection<CommonNK> datas)
    {
        if (datas is null || !datas.Any()) return;

        foreach (CommonNK data in datas)
        {
            await writer.WriteStartElementAsync(null, "CommonNK", null);
            if (!String.IsNullOrWhiteSpace(data.ActiveItems)) await writer.WriteAttributeStringAsync(null, "ActiveItems", null, data.ActiveItems);
            await writer.WriteEndElementAsync();
        }


    }
    internal static async Task CreateCommonPKAsync(XmlWriter writer, ICollection<CommonPK> datas)
    {
        if (datas is null || !datas.Any()) return;

        foreach (CommonPK? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "CommonPK", null);
            if (!String.IsNullOrWhiteSpace(data.ActiveItems)) await writer.WriteAttributeStringAsync(null, "ActiveItems", null, data.ActiveItems);
            await writer.WriteEndElementAsync();
        }
    }

    internal static async Task CreateNumberingAsync(XmlWriter writer, ICollection<Numbering> datas)
    {
        if (datas is null || !datas.Any()) return;

        foreach (Numbering? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "Numbering", null);
            if (!String.IsNullOrWhiteSpace(data.Mode)) await writer.WriteAttributeStringAsync(null, "Mode", null, data.Mode);
            if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
            await writer.WriteEndElementAsync();
        }
    }
}
