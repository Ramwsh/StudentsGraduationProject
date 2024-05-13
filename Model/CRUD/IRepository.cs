using StudentsGraduationProject.Model.Entities;

namespace StudentsGraduationProject.Model.CRUD;

/// <summary>
/// Интерфейс содержащий базовые процедуры для работы с БД.
/// Добавить в БД, получить из БД, Изменить в БД, Удалить из БД доменную сущность
/// </summary>
/// <typeparam name="T"></typeparam>
internal interface IRepository<T> where T : DomainEntity
{
    /// <summary>
    /// Добавить запись в БД
    /// </summary>
    /// <param name="model"></param>
    void Create(T model);
    /// <summary>
    /// Получить все записи таблицы
    /// </summary>
    /// <returns></returns>
    IEnumerable<T> Read();
    /// <summary>
    /// Изменить запись в таблице
    /// </summary>
    /// <param name="model"></param>
    void Update(int Id, T model);
    /// <summary>
    /// Удалить запись из таблицы
    /// </summary>
    /// <param name="model"></param>
    void Delete(T model);

    void CloseConnection();
}    

