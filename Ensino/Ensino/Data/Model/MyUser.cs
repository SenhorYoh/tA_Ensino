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
        public DateOnly BirthDate { get; set; }


        [Required(ErrorMessage = "O número de {0} é obrigatório")]
        [StringLength(17)]
        public string CellPhone { get; set; } = "";

        [StringLength(50)]
        [Display(Name = "ID de Utilizador")]
        public string? UserId { get; set; }

    }
}
