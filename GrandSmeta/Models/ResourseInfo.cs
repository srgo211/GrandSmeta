namespace GrandSmeta.Models;

public class ResourseInfo : BaseFilds
{
    /// <summary>Атрибуты ресурса  
    /// SnipSet Ресурс входит в расценку 
    /// Deleted Ресурс удален  
    /// Added Ресурс добавлен   
    /// Replaced Заменяющий ресурс(в этом случае обязательно присутствует тег Replaced, в котором указан удаленный ресурс) </summary>
    public string Attribs { get; set; }

    /// <summary>Код группы ресурсов</summary>
    public string GroupId { get; set; }

    /// <summary>Привязка ресурса к позиции (SysId) </summary>
    public string SysIdPosition { get; set; }
}