using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGraduationProject.Model.Entities;

/// <summary>
/// Класс для работы с таблицей "Студент".
/// </summary>
[Table("Студент")]
internal class Student : DomainEntity
{
    /// <summary>
    /// Номер зачетной книжки
    /// </summary>
    [Key]
    public int RBN { get; set; }

    /// <summary>
    /// Фамилия Имя студента
    /// </summary>
    public string FNStud { get; set; }

    /// <summary>
    /// Код группы
    /// </summary>
    public int CGp { get; set; }

    /// <summary>
    /// Код темы дипломной работы
    /// </summary>
    public int CSub { get; set; }
    /// <summary>
    /// Оценка за дипломную работу
    /// </summary>
    public int GGW { get; set; }
    /// <summary>
    /// Оценка за гос. экзамен
    /// </summary>
    public int GSE { get; set; }
}
