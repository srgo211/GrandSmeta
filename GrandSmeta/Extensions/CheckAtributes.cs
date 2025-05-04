namespace GrandSmeta.Extensions;

public class CheckAtributes
{
    /// <summary>главная-true; вспомогательная - false</summary>
    public static bool IsMain(string options)
    {
        if (String.IsNullOrWhiteSpace(options)) return false;
        if (options.Contains("OwnerMat") || options.Contains("RetOwnMat")) return true;
        return false;

    }

    /// <summary>Удаленная/неучтенная позиция </summary>
    public static bool IsAttribsDelete(string attribs, string options)
    {
        if (String.IsNullOrWhiteSpace(attribs) && String.IsNullOrEmpty(options)) return false;

        if (!String.IsNullOrWhiteSpace(attribs) && attribs.ToLower().Trim().Contains("deleted")) return true;      //Удаленная позиция        Deleted    
        if (!String.IsNullOrWhiteSpace(options) && options.ToLower().Trim().Contains("notcount")) return true;     //Неучтенная позиция
        if (!String.IsNullOrWhiteSpace(options) && options.ToLower().Trim().Contains("inactive")) return true;     //Неактивная позиция

        if (!String.IsNullOrWhiteSpace(options) && options.ToLower().Trim().Contains("deleted")) return true;      //Удаленная позиция        Deleted    
        if (!String.IsNullOrWhiteSpace(attribs) && attribs.ToLower().Trim().Contains("notcount")) return true;     //Неучтенная позиция
        if (!String.IsNullOrWhiteSpace(attribs) && attribs.ToLower().Trim().Contains("inactive")) return true;     //Неактивная позиция


        return false;
    }


    /// <summary>Не монтируемое оборудование/материал</summary>
    /// <param name="vr2001">вид работ код</param>
    /// <returns></returns>
    public static bool GetIsNotMountes(string vr2001)
    {
        if (String.IsNullOrWhiteSpace(vr2001)) return default;
        bool isNotMounted = false;
        if (vr2001.StartsWith("-")) isNotMounted = true;
        return isNotMounted;
    }



}
