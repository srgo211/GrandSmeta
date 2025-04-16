namespace GrandSmeta.Models;

/// <summary>Опции расчета коэффициента </summary>
public class KoefficientsOptions
{

    /// <summary>считать в единичной стоимости позиции</summary>
    public bool InPos { get; set; }

    /// <summary>Учитывать в Базисном и Базисно-Индексном расчете</summary>
    public bool Base { get; set; }
    /// <summary>К-т к задан в виде процента</summary>
    public bool Percent { get; set; }
    /// <summary>Учитывать в Ресурсном расчете в текущих ценах</summary>
    public bool Curr { get; set; }
    /// <summary>К-т к ПЗ необходимо применить ко всем статьям затрат</summary>
    public bool PzAll { get; set; }
    /// <summary>К-т к ЭМ необходимо применить к ЗПМ</summary>
    public bool EmAll { get; set; }
    /// <summary>К-т к МАТ применяется к количеству МАТ</summary>
    public bool MatQty { get; set; }
    /// <summary>К-т к ЭМ применяется к количеству ЭМ</summary>
    public bool EmQty { get; set; }
    /// <summary>К-т к ОЗП применяется к ТЗ рабочих</summary>
    public bool OzpTz { get; set; }
    /// <summary>К-т к ЗПМ применяется к ТЗ машинистов</summary>
    public bool ZpmTz { get; set; }
    /// <summary>К-т к ЭМ применяется в виде: (ЭМ-ЗПМ)*Кэм+ЗПМ*Кзпм</summary>
    public bool SeparEm { get; set; }
    /// <summary>Не учитывать коэффициент в расчете</summary>
    public bool Disabled { get; set; }
    /// <summary>Скрывать формулу</summary>
    public bool HideFx { get; set; }
}