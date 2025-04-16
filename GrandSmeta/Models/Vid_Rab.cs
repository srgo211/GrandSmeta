namespace GrandSmeta.Models;

public class Vid_Rab
{
    /// <summary>уникальный идентификатор вида работ, не может быть равен нулю </summary>
    public string ID { get; set; }
    /// <summary>Наименование вида работ </summary>
    public string Caption { get; set; }
    /// <summary>Норматив Накладных расходов </summary>
    public string Nacl { get; set; }
    /// <summary>Норматив Сметной прибыли </summary>
    public string Plan { get; set; }
    /// <summary>Категоря вида работ </summary>
    public string Category { get; set; }
    public string NrCode { get; set; }
    public string SpCode { get; set; }
    /// <summary>Маска начисления Накладных Расходов </summary>
    public string NaclMask { get; set; }
    /// <summary>Маска начисления сметной прибыли </summary>
    public string PlanMask { get; set; }
    /// <summary>Отнесение к графе ОС </summary>
    public string OsColumn { get; set; }
    /// <summary>Дополнительный норматив Накладных расходов для применения в текущем уровне цен </summary>
    public string NaclCurr { get; set; }
    /// <summary>Дополнительный норматив Сметной прибыли для применения в текущем уровне цен </summary>
    public string PlanCurr { get; set; }

    /// <summary>Коэффициент к НР для Базисно-Индексного метода </summary>
    public string NKI { get; set; }

    /// <summary>Коэффициент к СП для Базисно-Индексного метода </summary>
    public string PKI { get; set; }

    /// <summary>Коэффициент к НР для Ресурсного метода </summary>
    public string NKR { get; set; }

    /// <summary>Коэффициент к СП для Ресурсного метода </summary>
    public string PKR { get; set; }

    /// <summary>код индекса пересчета </summary>
    public string IndexCode { get; set; }
    /// <summary>Группа ресурсов для учета Погрузочно-разгрузочных работ и перевозки </summary>
    public string ResGroup { get; set; }

    /// <summary>Коэффициент к СП при расчете в базисных ценах </summary>
    public string PNB { get; set; }

    /// <summary> </summary>
    public string NKB { get; set; }

    /// <summary>Коэффициент к НР при расчете в базисных ценах </summary>
    public string NrspCode { get; set; }
}