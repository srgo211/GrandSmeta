using GrandSmeta.Extensions;
using GrandSmeta.Models.Itogs;
using System.Text;
using System.Xml;

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
    private ParserContextItog _context = null!;
    private ItogDataType _filter;
    public string? currentSysIdDoc;
    public string? currentSysIdChp;
    public string? currentSysIdPos;
    public bool isInsideItogRes;
    public List<Itog> CurrentItogList { get; } = new();


    public async Task<ParserContextItog> ExtractItogsAsync(string filePath, ItogScope scope, ItogDataType dataTypes = ItogDataType.All)
    {
        if (!File.Exists(filePath))
            return new();

        _context = new ();
        _filter = dataTypes;

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

        while (await reader.ReadAsync())
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                var name = reader.Name;
                var attributes = reader.GetAtributes() ?? new();
                DispatchElement(name, attributes, reader);
            }

            if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "ItogRes") isInsideItogRes = false;

           if (scope.Matches(ItogScope.DocumentLevel)) SetContext(ItogScope.DocumentLevel, reader);
           if (scope.Matches(ItogScope.ChapterLevel)) SetContext(ItogScope.ChapterLevel, reader);
           if (scope.Matches(ItogScope.PositionLevel)) SetContext(ItogScope.PositionLevel, reader);


        }

        return _context;
    }

    void SetContext(ItogScope itogScope, XmlReader reader)
    {
        string id = default;
        string scope = itogScope switch
        {
            ItogScope.DocumentLevel => "Document",
            ItogScope.ChapterLevel => "Chapter",
            ItogScope.PositionLevel => "Position",
            _ => "Unknown"
        };

        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == scope)
        {
            switch (itogScope)
            {
                case ItogScope.DocumentLevel:
                    id = currentSysIdDoc;
                    if (string.IsNullOrEmpty(id) || CurrentItogList?.Count == 0) return;
                    _context.ItogsByDocument[id] = new List<Itog>(CurrentItogList);
                    break;


                case ItogScope.ChapterLevel:
                    id = currentSysIdChp;
                    if (string.IsNullOrEmpty(id) || CurrentItogList?.Count == 0) return;
                    _context.ItogsByChapter[id] = new List<Itog>(CurrentItogList);
                    break;

                case ItogScope.PositionLevel:
                    id = currentSysIdPos;
                    if (string.IsNullOrEmpty(id) || CurrentItogList?.Count == 0) return;
                    _context.ItogsByPosition[id] = new List<Itog>(CurrentItogList);
                    break;

                default: return;
            }

            CurrentItogList.Clear();

        }
    }

    // 💡 Централизованный диспетчер без делегатов
    private void DispatchElement(string elementName, Dictionary<string, string> attributes, XmlReader reader)
    {
        switch (elementName)
        {
            case "Document":
                HandleDocument(attributes);
                break;

            case "Chapter":
                HandleChapter(attributes);
                break;

            case "Position":
                HandlePosition(attributes);
                break;

            case "ItogRes":
                HandleItogRes();
                break;

            case "Itog":
                HandleItog(reader);
                break;

            default:
                break;
        }
    }

    private void HandleDocument(Dictionary<string, string> attr)
    {
        currentSysIdDoc = "Document";
    }

    private void HandleChapter(Dictionary<string, string> attr)
    {
        attr.TryGetValue("SysID", out var sysId);
        currentSysIdChp = sysId;
    }

    private void HandlePosition(Dictionary<string, string> attr)
    {
        attr.TryGetValue("SysID", out var sysId);
        currentSysIdPos = sysId;
    }

    private void HandleItogRes()
    {
        isInsideItogRes = true;
        CurrentItogList.Clear();
    }

    private void HandleItog(XmlReader reader)
    {
        if (!isInsideItogRes)
            return;

        var (maxDepth, nodes) = GetItogDepthAndAttributes(reader, 1);
        var itog = ParseItog(nodes, _filter);
        if (itog is not null) CurrentItogList.Add(itog);
    }

    private (int maxDepth, Queue<ItogNode> nodes) GetItogDepthAndAttributes(XmlReader reader, int depth)
    {
        int maxSubDepth = depth;
        Queue<ItogNode> result = new();

        using var subtree = reader.ReadSubtree();
        subtree.Read(); // Переход к корневому элементу поддерева

        if (subtree.Name == "Itog")
        {
            var attributes = subtree.GetAtributes() ?? new();
            result.Enqueue(new ItogNode(depth, attributes));
        }

        while (subtree.Read())
        {
            if (subtree.NodeType == XmlNodeType.Element && subtree.Name == "Itog")
            {
                var (childDepth, childNodes) = GetItogDepthAndAttributes(subtree, depth + 1);
                maxSubDepth = Math.Max(maxSubDepth, childDepth);

                foreach (var child in childNodes)
                    result.Enqueue(child);
            }
        }

        return (maxSubDepth, result);
    }

    private static Itog? ParseItog(Queue<ItogNode> nodes, ItogDataType filter)
    {
        Itog? root = null;
        Stack<Itog> stack = new();
        bool isFilter = false;

        while (nodes.Count > 0)
        {
            var node = nodes.Dequeue();
            if (node is null) continue;

            var itog = node.Attributes.CreateDataModel<Itog>();
            if (itog is null) continue;

            bool isOnFilter = itog.DataType.Matches(filter);

            if (isOnFilter) isFilter = true;

            while (stack.Count >= node.Depth)
                stack.Pop();

            if (stack.Count > 0)
            {
                var parent = stack.Peek();
                if(parent.DataType.Matches(filter)) isFilter = true;
               
                if(!isFilter) continue;

                parent.Children ??= new();
                parent.Children.Add(itog);
            }
            else
            {
                root = itog;
            }

            stack.Push(itog);
        }

        nodes.Clear();
        nodes.TrimExcess();

        return isFilter ? root : null;
    }

    
}



