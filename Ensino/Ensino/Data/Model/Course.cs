using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensino.Data.Model
{
    public class Course{

        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Display(Name = "Disciplina")]
        [Required(ErrorMessage = "A {0} é obrigatório")]
        public string Name { get; set; } = "";

        [Display(Name = "Ano curricular")]
        public int CurricularYear { get; set; }

        [Display(Name = "Semestre")]
        public int Semester {  get; set; }

        /********************
         * Relacionamento 1-N com degree
        */

        [ForeignKey(nameof(Degree))]
        [Display(Name = "Curso")]
        [Required(ErrorMessage = "{0} é obrigátório(a)")]
        public int DegreeFK { get; set; }

        /***************
         * Relacionamentos N-M
         */

        /*Professor*/
        public ICollection<Professor> ListOfProfessors { get; set; } = [];

        /*Student*/
        public ICollection<Registration> ListOfRegistrations { get; set; } = [];


    }
}
