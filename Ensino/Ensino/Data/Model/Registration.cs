using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensino.Data.Model
{
    /// <summary>
    /// classe do relacionamento entre alunos e UCs
    /// </summary>
    /// 

    [PrimaryKey(nameof(StudentFK), nameof(CourseFK))]
    public class Registration{

        [Display(Name = "Data de Registo")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        //FK para student
        [ForeignKey(nameof(Student))]
        [Display(Name = "Nº de aluno")]
        [Required(ErrorMessage = "{0} é obrigatório(a)")]
        public int StudentFK { get; set; }
        public Student Student { get; set; } = null!;

        //FK para Course
        //[Key] na versão antiga
        [ForeignKey(nameof(Course))]
        [Display(Name = "Curso")]
        [Required(ErrorMessage = "{0} é obrigatório(a)")]
        public int CourseFK { get; set; }
        public Course Course { get; set; } = null!;

    }
}
