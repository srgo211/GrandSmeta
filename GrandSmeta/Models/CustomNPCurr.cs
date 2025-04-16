namespace GrandSmeta.Models;

/// <summary>Накладные расходы и сметная прибыль </summary>
public class CustomNPCurr
{
    /// <summary>величина накладных расходов</summary>
    public string Nacl { get; set; }
    /// <summary>макса начисления НР </summary>
    public string NaclMask { get; set; }
    /// <summary>величина сметной прибыли </summary>
    public string Plan { get; set; }
    /// <summary>маска начисления СП </summary>
    public string PlanMask { get; set; }
}