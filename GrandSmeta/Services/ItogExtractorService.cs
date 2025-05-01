using GrandSmeta.Extensions;
using GrandSmeta.Models.Itogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GrandSmeta.Services;

/// <summary>Область поиска итогов (можно комбинировать флагами) </summary>
[Flags]
public enum ItogScope
{
    /// <summary>Не указано</summary>
    None = 0,

    /// <summary>Итоги на уровне документа (глобальные)</summary>
    DocumentLevel = 1 << 0,

    /// <summary>Итоги по главам (Chapter)</summary>
    ChapterLevel = 1 << 1,

    /// <summary>Итоги по позициям (Position)</summary>
    PositionLevel = 1 << 2,

    /// <summary>Все уровни</summary>
    All = DocumentLevel | ChapterLevel | PositionLevel
}

/// <summary>Типы итогов, используемые в элементах <Itog> </summary>
[Flags]
public enum ItogDataType
{
    None = 0,

    /// <summary>На единицу в текущих ценах</summary>
    ForOneCurr = 1 << 0,

    /// <summary>ВСЕГО на физобъем</summary>
    TotalFo = 1 << 1,

    /// <summary>Накладные расходы</summary>
    Nacl = 1 << 2,

    /// <summary>Сметная прибыль</summary>
    Plan = 1 << 3,

    /// <summary>Итого с накладными и сметной прибылью</summary>
    TotalWithNP = 1 << 4,

    /// <summary>Итого прямые затраты в текущих ценах</summary>
    CleanPrice = 1 << 5,

    /// <summary>Корневой блок Накладных расходов</summary>
    NSummRoot = 1 << 6,

    /// <summary>Детализация Накладных расходов</summary>
    NSummDet = 1 << 7,

    /// <summary>Корневой блок Сметной прибыли</summary>
    PSummRoot = 1 << 8,

    /// <summary>Детализация Сметной прибыли</summary>
    PSummDet = 1 << 9,

    /// <summary>Итого по разделу</summary>
    ChapterTotal = 1 << 10,

    /// <summary>Группа работ (в т.ч. материальные, механизмы и т.п.)</summary>
    VrGroup = 1 << 11,

    /// <summary>Группа итогов по позиции (НР/СП)</summary>
    NPGroup = 1 << 12,

    /// <summary>Итоговая стоимость позиции без накладных и прибыли</summary>
    GroupInitial = 1 << 13,

    /// <summary>Группа "Строительные/Монтажные работы"</summary>
    OSGroup = 1 << 14,

    /// <summary>Материалы заказчика</summary>
    OwnerMatItog = 1 << 15,

    /// <summary>ВСЕГО по смете</summary>
    SmetaTotal = 1 << 16,

    /// <summary>Все значения</summary>
    All = ~0
}



/// <summary>
/// Сервис извлечения блоков <Itog> по указанной области и фильтру
/// </summary>
public sealed class ItogExtractorService
{
    public async Task<Dictionary<string, List<Itog>>> ExtractItogsAsync(string filePath, ItogScope scope, ItogDataType dataTypes = ItogDataType.All)
    {
        var context = new ParserContextItog();

        if (!File.Exists(filePath))
            return new();

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding encoding = Encoding.GetEncoding("windows-1254");

        var settings = new XmlReaderSettings
        {
            Async = true,
            IgnoreComments = true,
            IgnoreWhitespace = true,
            ConformanceLevel = ConformanceLevel.Auto
        };

        await using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = XmlReader.Create(stream, settings);

        var handlers = GetElementHandlers(context, scope, dataTypes);

        while (await reader.ReadAsync())
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                var name = reader.Name;
                var attributes = reader.GetAtributes() ?? new();

                if (handlers.TryGetValue(name, out var handler))
                {
                    handler(attributes, reader);
                }
            }
            else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "ItogRes")
            {
                if (context.CurrentSysId is { } id && context.CurrentItogList.Count > 0)
                {
                    context.ItogsBySysId[id] = new List<Itog>(context.CurrentItogList);
                }

                context.IsInsideItogRes = false;
                context.CurrentItogList.Clear();
            }
        }

        return context.ItogsBySysId;
    }    

    /// <summary>
    /// Возвращает карту обработчиков XML-элементов, привязанных к логике парсинга.
    /// </summary>
    /// <param name="context">Контекст обработки документа.</param>
    /// <returns>Словарь с именами XML-элементов и их обработчиками.</returns>
    private Dictionary<string, Action<Dictionary<string, string>, XmlReader>> GetElementHandlers(ParserContextItog context, ItogScope scope, ItogDataType filter)
    {
        return new(StringComparer.OrdinalIgnoreCase)
        {
            ["Document"] = (attr, _) =>
            {
                if (scope.HasFlag(ItogScope.DocumentLevel))
                {
                    context.CurrentSysId = $"Document";
                }
            },


            ["Chapter"] = (attr, _) =>
            {
                if (scope.HasFlag(ItogScope.ChapterLevel) && attr.TryGetValue("SysID", out var sysId))
                {
                    context.CurrentSysId = sysId;
                }
            },

            ["Position"] = (attr, _) =>
            {
                if (scope.HasFlag(ItogScope.PositionLevel) && attr.TryGetValue("SysID", out var sysId))
                    context.CurrentSysId = sysId;
            },

            ["ItogRes"] = (_, _) =>
            {
                context.IsInsideItogRes = true;
                context.CurrentItogList.Clear();
            },

            ["Itog"] = (_, reader) =>
            {
                if (!context.IsInsideItogRes)
                    return;

                using var subtree = reader.ReadSubtree();
                var element = XElement.Load(subtree);
                var itog = ParseItogElement(element, filter);

                if (itog != null)
                    context.CurrentItogList.Add(itog);
            }
        };
    }


   

    private static Itog? ParseItogElement(XElement element, ItogDataType filter)
    {
        var itog = new Itog
        {
            Caption = (string?)element.Attribute("Caption"),
            DataType = (string?)element.Attribute("DataType"),
            Status = (string?)element.Attribute("Status"),

            PZ = (string?)element.Attribute("PZ"),
            OZ = (string?)element.Attribute("OZ"),
            EM = (string?)element.Attribute("EM"),
            ZM = (string?)element.Attribute("ZM"),
            MT = (string?)element.Attribute("MT"),
            TZ = (string?)element.Attribute("TZ"),
            TM = (string?)element.Attribute("TM"),

            PZResult = (string?)element.Attribute("PZResult"),
            EMResult = (string?)element.Attribute("EMResult"),
            ZMResult = (string?)element.Attribute("ZMResult"),

            Children = new List<Itog>()
        };

        // Рекурсивно разбираем вложенные Itog
        foreach (var childElement in element.Elements("Itog"))
        {
            var child = ParseItogElement(childElement, filter);
            if (child != null)
            {
                itog.Children.Add(child);
            }
        }

        // Условие включения: если фильтр отключен или DataType подходит или есть дочерние
        bool include =
            filter == ItogDataType.All ||
            (!string.IsNullOrWhiteSpace(itog.DataType) && MapDataType(itog.DataType).HasFlag(filter)) ||
            itog.Children.Count > 0;

        return include ? itog : null;
    }

    private static ItogDataType MapDataType(string raw)
    {
        return raw.Trim() switch
        {
            "ForOneCurr" => ItogDataType.ForOneCurr,
            "TotalFo" => ItogDataType.TotalFo,
            "Nacl" => ItogDataType.Nacl,
            "Plan" => ItogDataType.Plan,
            "TotalWithNP" => ItogDataType.TotalWithNP,
            "CleanPrice" => ItogDataType.CleanPrice,
            "NSummRoot" => ItogDataType.NSummRoot,
            "NSummDet" => ItogDataType.NSummDet,
            "PSummRoot" => ItogDataType.PSummRoot,
            "PSummDet" => ItogDataType.PSummDet,
            "ChapterTotal" => ItogDataType.ChapterTotal,
            "VrGroup" => ItogDataType.VrGroup,
            "NPGroup" => ItogDataType.NPGroup,
            "GroupInitial" => ItogDataType.GroupInitial,
            "OSGroup" => ItogDataType.OSGroup,
            "OwnerMat Itog" => ItogDataType.OwnerMatItog,
            "SmetaTotal" => ItogDataType.SmetaTotal,
            _ => ItogDataType.None
        };
    }
}

internal sealed class ParserContextItog
{
    public string? CurrentSysId { get; set; }
    public bool IsInsideItogRes { get; set; } = false;
    public List<Itog> CurrentItogList { get; } = new();
    public Dictionary<string, List<Itog>> ItogsBySysId { get; } = new();
}

