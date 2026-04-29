using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensino.Data.Model
{
    /// <summary>
    /// classe que herda todas as caracteristicas do MyUser
    /// </summary>
    public class Student : MyUser {


        [Display(Name = "Nº de Aluno")]
        public int StudentNumber { get; set; }


        /// <summary>
        /// atributo auxiliar para ser usado no view
        /// para recolher a propina como string, e depois converter para decimal
        /// para ser guardada na base de dados
        /// </summary>
        [NotMapped] //esta anotação informa a EF para não criar o atributo na BD
        [Required(ErrorMessage = "A {0} é obrigatória")]
        [Display(Name = "Propina")]
        [StringLength(10)]
        [RegularExpression(@"[0-9]{1,7}([,.][0-9]{1,2})?", ErrorMessage = "A {0} deve ser um número com até 2 casas decimais")] //formatação da propina
        public string TuitionFeeAux { get; set; } = "";


        /// <summary>
        /// propina paga pelo estudante aquando matricula no degree
        /// </summary>
        [Precision(9, 2)]
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
