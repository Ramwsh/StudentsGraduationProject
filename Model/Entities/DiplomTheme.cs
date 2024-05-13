using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGraduationProject.Model.Entities;

/// <summary>
/// Класс для работы с таблицей "Тема"
/// </summary>
[Table("Тема")]
internal class DiplomTheme : DomainEntity
{
    /// <summary>
    /// Код темы
    /// </summary>
    [Key]
    public int CSub { get; set; }
    /// <summary>
    /// Название темы
    /// </summary>
    public string Sub { get; set; }
    /// <summary>
    /// Код преподавателя
    /// </summary>
    public int CTch { get; set; }
}
