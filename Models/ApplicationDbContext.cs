using Microsoft.EntityFrameworkCore;

namespace Auth0_Blazor.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
