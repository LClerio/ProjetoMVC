using MusicStore.Models;

namespace MusicStore.Repositories.Interfaces
{
    public interface IInstrumentoRepository
    {
        IEnumerable<Instrumento> instrumentos {  get; }
        IEnumerable<Instrumento> Destaque { get; }
        Instrumento GetInstrumentoById(int id);
    }
}
