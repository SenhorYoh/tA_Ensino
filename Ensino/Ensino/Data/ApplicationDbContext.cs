using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ensino.Data.Model;

namespace Ensino.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Ensino.Data.Model.MyUser> MyUser { get; set; } = default!;
    }
}
