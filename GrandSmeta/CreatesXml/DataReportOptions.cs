using GrandSmeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataReportOptions
{
    internal static async Task CreateReportOptionsAsync(XmlWriter writer, ReportOptions data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "ReportOptions", null);
        if (!String.IsNullOrWhiteSpace(data.Mode)) await writer.WriteAttributeStringAsync(null, "Mode", null, data.Mode);
        if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
        if (!String.IsNullOrWhiteSpace(data.Kk)) await writer.WriteAttributeStringAsync(null, "Kk", null, data.Kk);
        if (!String.IsNullOrWhiteSpace(data.RangingGroups)) await writer.WriteAttributeStringAsync(null, "RangingGroups", null, data.RangingGroups);
        if (!String.IsNullOrWhiteSpace(data.RangingMode)) await writer.WriteAttributeStringAsync(null, "RangingMode", null, data.RangingMode);
        if (data.RangingRates != null) await CreateRangingRatesAsync(writer, data.RangingRates);
        await writer.WriteEndElementAsync();
    }

    static async Task CreateRangingRatesAsync(XmlWriter writer, ICollection<RangingRates> datas)
    {
        if (datas is null || !datas.Any()) return;
        foreach (RangingRates? data in datas)
        {
            if (data is null) continue;
            await writer.WriteStartElementAsync(null, "RangingRates", null);
            if (!String.IsNullOrWhiteSpace(data.Mch)) await writer.WriteAttributeStringAsync(null, "Mch", null, data.Mch);
            if (!String.IsNullOrWhiteSpace(data.Mat)) await writer.WriteAttributeStringAsync(null, "Mat", null, data.Mat);
            if (!String.IsNullOrWhiteSpace(data.Tz)) await writer.WriteAttributeStringAsync(null, "Tz", null, data.Tz);
            if (!String.IsNullOrWhiteSpace(data.Eq)) await writer.WriteAttributeStringAsync(null, "Eq", null, data.Eq);
            if (!String.IsNullOrWhiteSpace(data.Tr)) await writer.WriteAttributeStringAsync(null, "Tr", null, data.Tr);
            if (!String.IsNullOrWhiteSpace(data.Load)) await writer.WriteAttributeStringAsync(null, "Load", null, data.Load);
            await writer.WriteEndElementAsync();

        }
    }
}
