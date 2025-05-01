using GrandSmeta.CreatesXml;
using GrandSmeta.Extensions;
using GrandSmeta.Interfaces;
using GrandSmeta.Models;
using System.Text;
using System.Xml;

namespace GrandSmeta.Services;

public class LocalSmetXmlService : ILocalSmetXmlService
{

    // <summary>
    /// Загружает и парсит XML-файл сметы, создавая объектную модель <see cref="Document"/>.
    /// </summary>
    /// <param name="filePath">Полный путь к XML-файлу.</param>
    /// <returns>Объект документа или пустой <see cref="Document"/>, если файл отсутствует.</returns>
    public async Task<Document?> LoadAsync(string filePath)
    {
        if (!File.Exists(filePath))
            return new Document();

        // Регистрация кодировки Windows-1254 (используется в Гранд Смете)
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding encoding = Encoding.GetEncoding("windows-1254");

        XmlReaderSettings settings = GetSettingsReader();

        using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using XmlReader reader = XmlReader.Create(stream, settings);

        // Контекст загрузки документа
        var context = new ParserContext();

        // Карта обработчиков XML-элементов
        var elementHandlers = GetElementHandlers(context);

        // Основной цикл чтения XML
        while (await reader.ReadAsync())
        {
            string name = reader.Name;

            if (reader.NodeType == XmlNodeType.Element)
            {
                // Чтение атрибутов текущего элемента
                Dictionary<string, string> attributes = reader.GetAtributes() ?? new();

                // Если есть соответствующий обработчик — вызываем
                if (elementHandlers.TryGetValue(name, out var handler))
                {
                    handler(attributes, reader);
                }

                // Флаг <Replaced>, особый случай
                if (name == "Replaced")
                {
                    context.IsReplaced = !reader.IsEmptyElement;
                }
            }

            else if (reader.NodeType == XmlNodeType.EndElement)
            {
                // Сброс флага <Replaced>
                if (name == "Replaced")
                {
                    context.IsReplaced = false;
                }

                // Дополнительная логика после закрытия элемента
                switch (name)
                {
                    case "Position":
                        context.CurrentPosition!.Koefficients = context.CurrentKoefficients;
                        context.CurrentPosition.PriceBase = context.CurrentPriceBase;
                        context.CurrentPosition.PriceCurr = context.CurrentPriceCurr;
                        context.CurrentPosition.Tzm2022 = context.CurrentTzm2022;

                        context.CurrentKoefficients = null;
                        context.CurrentPriceBase = null;
                        context.CurrentPriceCurr = null;
                        context.CurrentTzm2022 = null;
                        context.IsKoefPosition = false;
                        break;

                    case "Tzr":
                    case "Tzm":
                    case "Mch":
                    case "Mat":
                        var lastResource = GetLastResource(context, name);
                        if (lastResource != null)
                        {
                            lastResource.Koefficients = context.CurrentKoefficients;
                            lastResource.PriceBase    = context.CurrentPriceBase;
                            lastResource.PriceCurr    = context.CurrentPriceCurr;
                            lastResource.Tzm2022      = context.CurrentTzm2022;
                        }
                        context.CurrentKoefficients = null;
                        context.CurrentPriceBase = null;
                        context.CurrentPriceCurr = null;
                        context.CurrentTzm2022 = null;
                        break;

                    case "Koefficients":
                        if (!context.IsKoefPosition)
                        {
                            context.Document.Koefficients = context.CurrentKoefficients;
                            context.CurrentKoefficients = null;
                        }
                        break;
                }
            }
        }

        return context.Document;
    }

    /// <summary>
    /// Сохраняет объектную модель сметы в XML-файл.
    /// </summary>
    /// <param name="document">Смета для сохранения.</param>
    /// <param name="filePath">Путь к целевому файлу.</param>
    /// <returns>Задача, представляющая операцию сохранения.</returns>
    public async Task SaveAsync(Document document, string filePath)
    {
        var settings = GetSettingsWriter();
        XmlWriter writer = XmlWriter.Create(filePath, settings);

        try
        {
            await writer.WriteStartDocumentAsync();
            //await writer.WriteProcessingInstructionAsync("xml", "version='1.0' encoding='windows-1251'");
            await DataDocument.CreateDocumentAsync(writer, document);

            await writer.WriteEndDocumentAsync();
        }
        finally
        {
            await writer?.FlushAsync();
            writer?.Close();
            writer?.Dispose();
        }

    }


      

    private XmlWriterSettings GetSettingsWriter()
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Async = true;
        settings.Indent = true;
        settings.Encoding = Encoding.GetEncoding(1251);
        settings.OmitXmlDeclaration = false;
        settings.NewLineOnAttributes = false;
        settings.ConformanceLevel = ConformanceLevel.Auto;
        return settings;
    }  

    #region Helpers LoadXml
    private XmlReaderSettings GetSettingsReader()
    {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Async = true;
        settings.IgnoreComments = true;
        settings.ConformanceLevel = ConformanceLevel.Auto;

        return settings;
    }

    /// <summary>
    /// Возвращает карту обработчиков XML-элементов, привязанных к логике парсинга.
    /// </summary>
    /// <param name="context">Контекст обработки документа.</param>
    /// <returns>Словарь с именами XML-элементов и их обработчиками.</returns>
    private Dictionary<string, Action<Dictionary<string, string>, XmlReader>> GetElementHandlers(ParserContext context)
    {
        return new(StringComparer.OrdinalIgnoreCase)
        {
            ["Document"] = (attr, _) =>
                context.Document = attr.CreateDataModel<Document>(),

            ["Chapters"] = (attr, _) =>
            {
                var chapters = attr.CreateDataModel<Chapters>();
                chapters.Chapter = new List<Chapter>();
                context.Document.Chapters = chapters;
            },

            ["Chapter"] = (attr, _) =>
            {
                var chapter = attr.CreateDataModel<Chapter>();
                chapter.Guid = context.GuidCounter++;
                chapter.Position = new List<Position>();
                chapter.Comment = new List<Comment>();
                context.Document.Chapters?.Chapter?.Add(chapter);
                context.CurrentChapter = chapter;
            },

            ["Position"] = (attr, _) =>
            {
                context.IsKoefPosition = true;
                var position = attr.CreateDataModel<Position>();
                bool isNotMount = position.Vr2001?.StartsWith("-") ?? false;

                position.ChapterSysId = context.CurrentChapter?.SysID;
                position.Guid = context.GuidCounter++;
                position.IdPosition = isNotMount ? ++context.IdPositionCounter : context.IdPositionCounter;

                context.CurrentChapter?.Position?.Add(position);
                context.CurrentPosition = position;
            },

            ["Quantity"] = (attr, _) =>
                context.CurrentPosition!.Quantitys = attr.CreateDataModel<Quantity>(),

            ["Resources"] = (attr, _) =>
            {
                var res = attr.CreateDataModel<Resources>();
                res.Tzr = new List<Tzr>();
                res.Tzm = new List<Tzm>();
                res.Mch = new List<Mch>();
                res.Mat = new List<Mat>();

                context.CurrentPosition!.IdPosition = ++context.IdPositionCounter;
                context.CurrentPosition.Resources = res;
            },

            ["Tzr"] = (attr, _) =>
            {
                var tzr = attr.CreateDataModel<Tzr>();
                if (tzr is not null)
                {
                    tzr.SysIdPosition = context.CurrentPosition?.SysID;
                    tzr.Guid = context.GuidCounter++;
                    tzr.IdPosition = context.IdPositionCounter;
                    context.CurrentPosition?.Resources?.Tzr?.Add(tzr);
                }
            },

            ["Tzm"] = (attr, _) =>
            {
                var tzm = attr.CreateDataModel<Tzm>();
                if (tzm is not null)
                {
                    tzm.SysIdPosition = context.CurrentPosition?.SysID;
                    tzm.Guid = context.GuidCounter++;
                    tzm.IdPosition = context.IdPositionCounter;
                    context.CurrentPosition?.Resources?.Tzm?.Add(tzm);
                }
            },

            ["Mch"] = (attr, _) =>
            {
                var mch = attr.CreateDataModel<Mch>();
                if (mch is not null)
                {
                    mch.SysIdPosition = context.CurrentPosition?.SysID;
                    mch.Guid = context.GuidCounter++;
                    mch.IdPosition = context.IdPositionCounter;
                    context.CurrentPosition?.Resources?.Mch?.Add(mch);
                }
            },

            ["Mat"] = (attr, _) =>
            {
                var mat = attr.CreateDataModel<Mat>();
                if (mat is not null)
                {
                    mat.SysIdPosition = context.CurrentPosition?.SysID;
                    mat.Guid = context.GuidCounter++;
                    mat.IdPosition = context.IdPositionCounter;
                    context.CurrentPosition?.Resources?.Mat?.Add(mat);
                }
            },

            ["PriceBase"] = (attr, _) =>
            {
                if (!context.IsReplaced)
                    context.CurrentPriceBase = attr.CreateDataModel<Price>();
            },

            ["PriceCurr"] = (attr, _) =>
            {
                if (!context.IsReplaced)
                    context.CurrentPriceCurr = attr.CreateDataModel<Price>();
            },

            ["Koefficients"] = (attr, _) =>
            {
                var kf = attr.CreateDataModel<Koefficients>();
                kf.K = new List<K>();
                context.CurrentKoefficients = kf;
            },

            ["K"] = (attr, _) =>
                context.CurrentKoefficients?.K?.Add(attr.CreateDataModel<K>()),

            ["Tzm2022"] = (attr, _) =>
            {
                if (!context.IsReplaced)
                    context.CurrentTzm2022 = attr.CreateDataModel<Tzm2022>();
            },

            ["WorksList"] = (attr, _) =>
            {
                var wl = attr.CreateDataModel<WorksList>();
                wl.Work = new List<Work>();
                context.CurrentPosition!.WorksList = wl;
            },

            ["Work"] = (attr, _) =>
                context.CurrentPosition?.WorksList?.Work?.Add(attr.CreateDataModel<Work>()),

            ["CustomNPCurr"] = (attr, _) =>
                context.CurrentPosition!.CustomNPCurr = attr.CreateDataModel<CustomNPCurr>(),

            ["Comment"] = (attr, _) =>
                context.CurrentChapter?.Comment?.Add(attr.CreateDataModel<Comment>()),

            ["Itog"] = (attr, _) =>
            {
                var itog = attr.CreateDataModel<Itog>();
                itog.ItogBim   = new List<BaseItog>();
                itog.ItogNoIdx = new List<BaseItog>();
                itog.ItogRes   = new List<BaseItog>();
                context.CurrentChapter!.Itog = itog;
            },

            ["ItogBim"] = (attr, _) =>
                context.CurrentChapter?.Itog?.ItogBim?.Add(attr.CreateDataModel<BaseItog>()),

            ["ItogNoIdx"] = (attr, _) =>
                context.CurrentChapter?.Itog?.ItogNoIdx?.Add(attr.CreateDataModel<BaseItog>()),

            ["ItogRes"] = (attr, _) =>
                context.CurrentChapter?.Itog?.ItogRes?.Add(attr.CreateDataModel<BaseItog>()),

            ["Properties"] = (attr, _) =>
                context.Document.Properties = attr.CreateDataModel<Properties>(),

            ["RegionalK"] = (attr, _) =>
                context.Document.RegionalK = attr.CreateDataModel<RegionalK>(),

            ["TerZoneK"] = (attr, _) =>
                context.Document.TerZoneK = attr.CreateDataModel<TerZoneK>(),

            ["WinterCatalog"] = (attr, _) =>
            {
                var wc = attr.CreateDataModel<WinterCatalog>();
                wc.CommonWinterK = new List<CommonWinterK>();
                context.Document.WinterCatalog = wc;
            },

            ["CommonWinterK"] = (attr, _) =>
                context.Document.WinterCatalog?.CommonWinterK?.Add(attr.CreateDataModel<CommonWinterK>()),

            ["RegionInfo"] = (attr, _) =>
                context.Document.RegionInfo = attr.CreateDataModel<RegionInfo>(),

            ["FRSN_Info"] = (attr, _) =>
                context.Document.FRSN_Info = attr.CreateDataModel<FRSN_Info>(),

            ["Overhd_Info"] = (attr, _) =>
                context.Document.FRSN_Info!.Overhd_Info = attr.CreateDataModel<Overhd_Info>(),

            ["Profit_Info"] = (attr, _) =>
                context.Document.FRSN_Info!.Profit_Info = attr.CreateDataModel<Profit_Info>(),

            ["GsDocSignatures"] = (attr, _) =>
            {
                var gs = attr.CreateDataModel<GsDocSignatures>();
                gs.Item = new List<Item>();
                context.Document.GsDocSignatures = gs;
            },

            ["Item"] = (attr, _) =>
                context.Document.GsDocSignatures?.Item?.Add(attr.CreateDataModel<Item>()),

            ["Parameters"] = (attr, _) =>
            {
                var prm = attr.CreateDataModel<Parameters>();
                prm.CommonNK  = new List<CommonNK>();
                prm.CommonPK  = new List<CommonPK>();
                prm.Numbering = new List<Numbering>();
                context.Document.Parameters = prm;
            },

            ["CommonNK"] = (attr, _) =>
                context.Document.Parameters?.CommonNK?.Add(attr.CreateDataModel<CommonNK>()),

            ["CommonPK"] = (attr, _) =>
                context.Document.Parameters?.CommonPK?.Add(attr.CreateDataModel<CommonPK>()),

            ["Numbering"] = (attr, _) =>
                context.Document.Parameters?.Numbering?.Add(attr.CreateDataModel<Numbering>()),

            ["Indexes"] = (attr, _) =>
            {
                var idx = attr.CreateDataModel<Indexes>();
                idx.CategoryIndexes = new List<CategoryIndexes>();
                context.Document.Indexes = idx;
            },

            ["CategoryIndexes"] = (attr, _) =>
                context.Document.Indexes?.CategoryIndexes?.Add(attr.CreateDataModel<CategoryIndexes>()),

            ["AddZatrats"] = (attr, _) =>
            {
                var az = attr.CreateDataModel<AddZatrats>();
                az.AddZatrGlava = new List<AddZatrGlava>();
                context.Document.AddZatrats = az;
            },

            ["AddZatrGlava"] = (attr, _) =>
            {
                var glava = attr.CreateDataModel<AddZatrGlava>();
                context.CurrentAddZatrList = new();
                glava.AddZatr = context.CurrentAddZatrList;
                context.Document.AddZatrats?.AddZatrGlava?.Add(glava);
            },

            ["AddZatr"] = (attr, _) =>
                context.CurrentAddZatrList?.Add(attr.CreateDataModel<AddZatr>()),

            ["OsInfo"] = (attr, _) =>
            {
                var os = attr.CreateDataModel<OsInfo>();
                os.CCChapter = new List<CCChapter>();
                context.Document.OsInfo = os;
            },

            ["CCChapter"] = (attr, _) =>
                context.Document.OsInfo?.CCChapter?.Add(attr.CreateDataModel<CCChapter>()),

            ["CennikAutoLoad"] = (attr, _) =>
                context.Document.CennikAutoLoad = attr.CreateDataModel<CennikAutoLoad>(),

            ["DocLink"] = (attr, _) =>
            {
                if (context.Document.CennikAutoLoad is not null)
                    context.Document.CennikAutoLoad.DocLink = attr.CreateDataModel<DocLink>();
            },

            ["VidRab_Catalog"] = (attr, _) =>
            {
                var catalog = attr.CreateDataModel<VidRab_Catalog>();
                context.CurrentVids_Rab = new();
                catalog.Vids_Rab = context.CurrentVids_Rab;
                context.Document.VidRab_Catalog = catalog;
            },

            ["Vids_Rab"] = (attr, _) =>
            {
                var vids = attr.CreateDataModel<Vids_Rab>();
                context.CurrentVidRab_Group = new();
                vids.VidRab_Group = context.CurrentVidRab_Group;
                context.CurrentVids_Rab.Add(vids);
            },

            ["VidRab_Group"] = (attr, _) =>
            {
                var group = attr.CreateDataModel<VidRab_Group>();
                context.CurrentVid_Rab = new();
                group.Vid_Rab = context.CurrentVid_Rab;
                context.CurrentVidRab_Group.Add(group);
            },

            ["Vid_Rab"] = (attr, _) =>
                context.CurrentVid_Rab.Add(attr.CreateDataModel<Vid_Rab>()),

            ["ReportOptions"] = (attr, _) =>
            {
                var ro = attr.CreateDataModel<ReportOptions>();
                ro.RangingRates = new List<RangingRates>();
                context.Document.ReportOptions = ro;
            },

            ["RangingRates"] = (attr, _) =>
                context.Document.ReportOptions?.RangingRates?.Add(attr.CreateDataModel<RangingRates>()),

            ["Variables"] = (attr, _) =>
            {
                var vars = attr.CreateDataModel<Variables>();
                vars.Variable = new List<Variable>();
                context.Document.Variables = vars;
            },

            ["Variable"] = (attr, _) =>
                context.Document.Variables?.Variable?.Add(attr.CreateDataModel<Variable>())
        };
    }

    /// <summary>
    /// Возвращает последний добавленный ресурс определённого типа для текущей позиции.
    /// Используется при завершении элементов ресурса (например, Tzr, Tzm).
    /// </summary>
    /// <param name="context">Контекст XML-разбора.</param>
    /// <param name="typeName">Имя типа ресурса (например, "Tzr", "Tzm").</param>
    /// <returns>Последний ресурс или null, если не найден.</returns>
    private static ResourseInfo? GetLastResource(ParserContext context, string typeName)
    {
        return typeName switch
        {
            "Tzr" => context.CurrentPosition?.Resources?.Tzr?.LastOrDefault(),
            "Tzm" => context.CurrentPosition?.Resources?.Tzm?.LastOrDefault(),
            "Mch" => context.CurrentPosition?.Resources?.Mch?.LastOrDefault(),
            "Mat" => context.CurrentPosition?.Resources?.Mat?.LastOrDefault(),
            _ => null
        };
    }
    #endregion
}
