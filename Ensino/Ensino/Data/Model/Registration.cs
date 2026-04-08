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

        public DateTime RegistrationDate { get; set; }

        //FK para student
        [Key]
        public int StudentFK { get; set; }
        public Student Student { get; set; } = null!;

        //FK para Course
        [Key]
        public int CourseFK { get; set; }
        public Course Course { get; set; } = null!;

    }
}
