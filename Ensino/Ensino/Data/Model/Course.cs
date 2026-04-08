using System.ComponentModel.DataAnnotations;

namespace Ensino.Data.Model
{
    public class Course{

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}
