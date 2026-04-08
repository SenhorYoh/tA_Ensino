using System.ComponentModel.DataAnnotations;

namespace Ensino.Data.Model
{
    public class MyUser{

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string CellPhone { get; set; }
        public string UserId { get; set; }

    }
}
