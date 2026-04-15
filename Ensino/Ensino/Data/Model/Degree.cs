using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensino.Data.Model
{
    /// <summary>
    /// classe que representa os cursos
    /// </summary>
    public class Degree{

        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Curso")]
        [Required(ErrorMessage = "{0} é obrigátório(a)")]
        public string Name { get; set; } = "";

        [StringLength(50)]
        [Display(Name = "Logotipo")]
        public string? Logotype { get; set; }

        
        

    }
}
