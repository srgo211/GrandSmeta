namespace GrandSmeta.Models;

public class Position : BaseFilds
{
    /// <summary>Флаг у позиции (Информационный, пользовательский)</summary>
    public string ItemFlags { get; set; }

    /// <summary>Системный номер позиции (не меняется при перенумерации и перемещении позиций в пределах сметы)</summary>
    public string SysID { get; set; }

    /// <summary>Уровень цен позиции</summary>
    public string PriceLevel { get; set; }


    /// <summary>Флаг "Расчитывать ПЗ как сумму статей" единичной стоимости позиции</summary>
    public string PzSync { get; set; }

    /// <summary>Код вида работ 2001 года</summary>
    public string Vr2001 { get; set; }



    /// <summary>Ссылка на чертежи, спецификации (Пользовательский комментарий 1)</summary>
    public string UserComment1 { get; set; }

    /// <summary>Заметки, пояснения (Пользовательский комментарий 2)</summary>
    public string UserComment2 { get; set; }

    /// <summary>Цвет заливки позиции</summary>
    public string ColorIndex { get; set; }


    /// <summary>Комментарий из базы к расценке, обычно – ссылка на утверждающий документ</summary>
    public string DBComment { get; set; }

    /// <summary>Флаг наличия коэффициентов (TechK) и/или примечаний к расценке в нормативной базе</summary>
    public string DBFlags { get; set; }

    /// <summary>признак подчиненной строки</summary>
    string SlaveRow { get; set; }

    /// <summary>Комментарий к позции</summary>
    public string Comment { get; set; }

    /// <summary>Закладка (указатель для быстрого открытия документа)</summary>
    public string Bookmark { get; set; }

    /// <summary>индивидуальный поправочный коэффициент к значению накладных расходов при расчете в базисных ценах </summary>
    public string NKB { get; set; }
    /// <summary>индивидуальный поправочный коэффициент к значению накладных расходов при расчете базисно-индексным методом </summary>
    public string NKI { get; set; }
    /// <summary>индивидуальный поправочный коэффициент к значению накладных расходов при расчете ресурсным методом </summary>
    public string NKR { get; set; }
    /// <summary>индивидуальный поправочный коэффициент к значению сметной прибыли при расчете в базисных ценах </summary>
    public string PNB { get; set; }
    /// <summary>индивидуальный поправочный коэффициент к значению сметной прибыли при расчете базисно-индексным методом </summary>
    public string PKI { get; set; }
    /// <summary>индивидуальный поправочный коэффициент к значению сметной прибыли при расчете ресурсным методом </summary>
    public string PKR { get; set; }

    /// <summary>Тип расчета стоимости базисных цен </summary>
    public string BaseCalcMode { get; set; }
    /// <summary>Код Зимнего удорожания </summary>
    public string WinterK { get; set; }


    /// <summary>Идентификатор родительской главы, НЕТ в XML</summary>
    public string ChapterSysId { get; set; }
    public int GuidChapter { get; set; }

    /// <summary>Обоснование ненормируемого вспомогательного материала</summary>
    public string AuxMatCode { get; set; }

    /// <summary>Дополнитеольный номер ненормируемого вспомогательного материала</summary>
    public string AuxMat { get; set; }


    public Resources Resources { get; set; }

    public WorksList WorksList { get; set; }

    /// <summary>Индивидуальные НР и СП для расчета в текущих ценах </summary>
    public CustomNPCurr CustomNPCurr { get; set; }
    public Quantity Quantitys { get; set; }
}