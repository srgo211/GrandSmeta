namespace GrandSmeta.Models;

/// <summary>парамертры Переменной </summary>
public class Variable
{
    /// <summary>Наименование переменной </summary>
    public string Caption { get; set; }

    /// <summary>Идентификатор переменной (должен начинаться с буквы, за исключением Г, К) список исключений приведен в документации </summary>
    public string Identifier { get; set; }

    /// <summary>Значение переменной </summary>
    public string Value { get; set; }

    /// <summary>Тип используемого к-та, Formula - в виде формулы</summary>
    public string Kind { get; set; }
}