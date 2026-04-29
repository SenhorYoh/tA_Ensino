using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ensino.Data.Model;

namespace Ensino.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Ensino.Data.Model.MyUser> MyUser { get; set; } = default!;
        public DbSet<Ensino.Data.Model.Student> Student { get; set; } = default!;

        public DbSet<Ensino.Data.Model.Degree> Degree { get; set; } = default!;
        public DbSet<Ensino.Data.Model.Course> Course { get; set; } = default!;
        public DbSet<Ensino.Data.Model.Professor> Professor { get; set; } = default!;
        public DbSet<Ensino.Data.Model.Registration> Registration { get; set; } = default!;
    }
}
