using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGraduationProject.Model.Entities;

/// <summary>
/// Сущность для работы с таблицей "Группа"
/// </summary>
[Table("Группа")]
internal class Group : DomainEntity
{
    /// <summary>
    /// Код группы.
    /// </summary>
    [Key]
    public int CGp { get; set; }
    /// <summary>
    /// Название группы
    /// </summary>
    public string Gp { get; set; }

    /// <summary>
    /// Код факультета
    /// </summary>
    public int CFacl { get; set; }
}
