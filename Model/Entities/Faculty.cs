using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGraduationProject.Model.Entities;

[Table("Факультет")]
internal class Faculty : DomainEntity
{
    /// <summary>
    /// Код факультета
    /// </summary>
    [Key]
    public int CFacl { get; set; }

    /// <summary>
    /// Название факультета
    /// </summary>
    public string Facl { get; set; }
}
