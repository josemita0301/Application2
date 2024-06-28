using Auth0_Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth0_Blazor.Services
{
    public class EmpleadoService
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task AddEmpleadoAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmpleadoAsync(Empleado empleado)
        {
            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmpleadoAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
