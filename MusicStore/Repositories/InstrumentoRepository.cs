using Microsoft.EntityFrameworkCore;
using MusicStore.context;
using MusicStore.Models;
using MusicStore.Repositories.Interfaces;

namespace MusicStore.Repositories
{
    public class InstrumentoRepository : IInstrumentoRepository
    {
        private readonly AppDbContext _context;

        public InstrumentoRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Instrumento> instrumentos => _context.Instrumentos
            .Include(c => c.Categoria);

        public IEnumerable<Instrumento> Destaque => _context.Instrumentos
            .Where(d => d.Destaque)
            .Include(c => c.Categoria);

        public Instrumento GetInstrumentoById(int id)
        {
           return _context.Instrumentos.FirstOrDefault(i => i.InstrumentoId == id);
        }
    }
}
