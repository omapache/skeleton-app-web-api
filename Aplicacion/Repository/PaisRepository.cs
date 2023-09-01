using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PaisRepository  : GenericRepository<Pais>, IPais
    {
        protected readonly SkeletonAppWebApiContext _context;
        
        public PaisRepository(SkeletonAppWebApiContext context) : base (context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {

            return await _context.Paises
                .Include(p => p.Departamentos).ThenInclude(c=>c.Ciudades)
                .ToListAsync();
        }

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
            .Include(p => p.Departamentos)
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
}