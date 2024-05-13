using Microsoft.EntityFrameworkCore;
using StudentsGraduationProject.Model.Entities;

namespace StudentsGraduationProject.Model.Context;

/// <summary>
/// Класс, задающий работу с контекстом базы данных.
/// Контекст базы данных - База данных "Дипломный проект".
/// </summary>
/// <typeparam name="T"></typeparam>
internal class ApplicationContext<T> : DbContext, IDisposable where T : DomainEntity
{
    /// <summary>
    /// Коллекция записей из базы данных DomainEntity таблицы
    /// </summary>
    public DbSet<T> Items { get; set; } = null!;

    /// <summary>
    /// OnConfiguring используется, чтобы установить соединение с базой данных .mdb
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
        string connectionSting = ConnectionHelper.ConnectionString;
        optionsBuilder.UseJet(connectionSting);
    }

    /// <summary>
    /// Закрыть соединение с базой данных.
    /// Высвободить ресурсы.
    /// </summary>
    public void CloseConnection() => base.Dispose();
}
