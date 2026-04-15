namespace Ensino.Data.Model
{
    /// <summary>
    /// classe que representa os professores (herda MyUser)
    /// </summary>
    public class Professor : MyUser{

        public ICollection<Course> ListOfCourses { get; set; } = [];
    }
}
