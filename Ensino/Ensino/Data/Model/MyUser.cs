using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ensino.Data.Model
{
    /// <summary>
    /// classe do utilizador 
    /// </summary>
    public class MyUser{

        [Key]
        public int Id { get; set; }

        [Display(Name = "Utilizador")]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(50)]
        public string Name { get; set; } = "";

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        public DateOnly BirthDate { get; set; }


        [Display(Name = "Telemóvel")]
        [Required(ErrorMessage = "O número de {0} é obrigatório")]
        [StringLength(17)]
        [RegularExpression(@"\+?[0-9]{9,18}")] //telemóvel em Portugal
        public string CellPhone { get; set; } = "";

        [StringLength(50)]
        public string? UserId { get; set; }

    }
}
