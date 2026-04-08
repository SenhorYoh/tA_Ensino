namespace Ensino.Data.Model
{
    /// <summary>
    /// classe que herda todas as caracteristicas do MyUser
    /// </summary>
    public class Student : MyUser{

        public int StudentNumber { get; set; }
        public decimal TuitionFee { get; set; }


    }
}
