using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGraduationProject.Model.Entities;

/// <summary>
/// Класс для работы с таблицей "Преподаватель".
/// </summary>
[Table("Преподаватель")]
internal class Teacher : DomainEntity
{
    /// <summary>
    /// Код преподавателя
    /// </summary>
    [Key]
    public int CTch { get; set; }

    /// <summary>
    /// Фамилия Имя преподавателя
    /// </summary>
    public string FNTch { get; set; }

    /// <summary>
    /// Степень учености преподавателя
    /// </summary>
    public string DTch { get; set; }

    /// <summary>
    /// Звание преподавателя
    /// </summary>
    public string RTch { get; set; }

    /// <summary>
    /// Кафедра преподавателя
    /// </summary>
    public string DepTch { get; set; }

    /// <summary>
    /// Номер телефона преподавателя
    /// </summary>
    public string PnTch { get; set; }

    /// <summary>
    /// Email преподавателя
    /// </summary>
    public string Email { get; set; }
}
