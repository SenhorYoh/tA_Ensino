using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensino.Data.Model
{
    /// <summary>
    /// classe que herda todas as caracteristicas do MyUser
    /// </summary>
    public class Student : MyUser{

        [Key]
        [Display(Name = "Nº de Aluno")]
        public int StudentNumber { get; set; }

        [Precision(8, 2)]
        [Display(Name = "Propina")]
        public decimal TuitionFee { get; set; }

        [Display(Name = "Data de Registo")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        /*************
         * Relacionamento 1-N Degree
        */
        [ForeignKey(nameof(Degree))]
        [Display(Name = "Curso")]
        [Required(ErrorMessage = "{0} é obrigátório(a)")]
        public int DegreeFK { get; set; }




    }
}
