using System.Xml;
using GrandSmeta.Models;

namespace GrandSmeta.CreatesXml;

internal class DataVariable
{
    internal static async Task CreateVariablesAsync(XmlWriter writer, Variables? variables)
    {

        if (variables is null) return;

        ICollection<Variable>? datas = variables.Variable;
        if (datas is null || !datas.Any()) return;
        await writer.WriteStartElementAsync(null, "Variables", null);

        foreach (Variable data in datas)
        {
            await writer.WriteStartElementAsync(null, "Variable", null);


            if (!string.IsNullOrWhiteSpace(data.Caption)) await writer.WriteAttributeStringAsync(null, "Caption", null, data.Caption);
            if (!string.IsNullOrWhiteSpace(data.Identifier)) await writer.WriteAttributeStringAsync(null, "Identifier", null, data.Identifier);
            if (!string.IsNullOrWhiteSpace(data.Value)) await writer.WriteAttributeStringAsync(null, "Value", null, data.Value);
            if (!string.IsNullOrWhiteSpace(data.Kind)) await writer.WriteAttributeStringAsync(null, "Kind", null, data.Kind);

            await writer.WriteEndElementAsync();
        }

        await writer.WriteEndElementAsync();
    }


}