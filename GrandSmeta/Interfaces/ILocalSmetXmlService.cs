using GrandSmeta.Models;

namespace GrandSmeta.Interfaces;

public interface ILocalSmetXmlService
{
    /// <summary>
    /// Загружает локальный XML-файл сметы и преобразует его в объектную модель.
    /// </summary>
    /// <param name="filePath">Путь к XML-файлу сметы.</param>
    /// <returns>Объектная модель сметы.</returns>
    Task<Document?> LoadAsync(string filePath);

    /// <summary>
    /// Сохраняет объектную модель сметы в XML-файл.
    /// </summary>
    /// <param name="document">Смета для сохранения.</param>
    /// <param name="filePath">Путь к целевому файлу.</param>
    /// <returns>Задача, представляющая операцию сохранения.</returns>
    Task SaveAsync(Document document, string filePath);
}
