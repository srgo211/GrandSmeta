namespace GrandSmeta.Models;

public class Quantity
{
    /// <summary>Расчётные строки</summary>
    public string CalcRows { get; set; }

    /// <summary>формула расчета</summary>
    public string Fx { get; set; }

    /// <summary>Количество знаков после запятой (точность расчета) "6" - 6 знаков после запятой(значение по умолчанию, эквивалентно отсутствию атрибута),"0" - целое число, "-3" округление до тысяч</summary>
    public string Precision { get; set; }

    /// <summary>К-нт к формуле </summary>
    public string KUnit { get; set; }

    /// <summary>Коэффициент кратности объёма </summary>
    public string KMult { get; set; }

    /// <summary>вычисленное значение формулы </summary>
    public string Result { get; set; }

    /// <summary></summary>
    public string RoundDirection { get; set; }
}