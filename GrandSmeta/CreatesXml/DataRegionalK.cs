using GrandSmeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GrandSmeta.CreatesXml;

public class DataRegionalK
{
    internal async static Task CreateRegionalKAsync(XmlWriter writer, RegionalK data)
    {
        if (data is null) return;
        await writer.WriteStartElementAsync(null, "RegionalK", null);
        if (!String.IsNullOrWhiteSpace(data.Options)) await writer.WriteAttributeStringAsync(null, "Options", null, data.Options);
        await writer.WriteEndElementAsync();
    }
}
