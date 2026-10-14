using Clase6.EF.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Clase6.EF.Repositorios
{

    public interface ILibroRepositorio
    {
        Task<List<Libro>> ListarAsync();
        Task<List<TematicaLibro>> ObtenerOCrearTematicasAsync(IEnumerable<string> nombres);
        Task<Libro?> BuscarPorTituloAsync(string titulo);
        Task<Pagina?> ObtenerPaginaAsync(int libroId, int numero);
        Task<int> ContarPaginasAsync(int libroId);
        Task GuardarAsync(Libro libro);
    }

    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly JugueteriaDbContext _db;

        public LibroRepositorio(JugueteriaDbContext db)
        {
            _db = db;
        }

        public async Task<Libro?> BuscarPorTituloAsync(string titulo)
        {
            return await _db.Libros.FirstOrDefaultAsync(l => l.Titulo.Contains(titulo));
        }

        public async Task<Pagina?> ObtenerPaginaAsync(int libroId, int numero)
        {
            return await _db.Paginas
                .Include(p => p.Libro)
                .FirstOrDefaultAsync(p => p.LibroId == libroId && p.Numero == numero);
        }

        public async Task<int> ContarPaginasAsync(int libroId)
        {
            return await _db.Paginas.CountAsync(p => p.LibroId == libroId);
        }

        public async Task GuardarAsync(Libro libro)
        {
            _db.Libros.Add(libro);
            await _db.SaveChangesAsync();
        }

        public async Task<List<TematicaLibro>> ObtenerOCrearTematicasAsync(IEnumerable<string> nombres)
        {
            var limpios = nombres
                .Select(n => n.Replace("Category:", "").Trim())
                .Where(n => n != "")
                .Distinct()
                .ToList();

            var existentes = await _db.TematicasLibro
                .Where(t => limpios.Contains(t.Nombre))
                .ToListAsync();

            var nuevas = limpios
                .Except(existentes.Select(t => t.Nombre))
                .Select(n => new TematicaLibro { Nombre = n });

            return existentes.Concat(nuevas).ToList();
        }

        public async Task<List<Libro>> ListarAsync()
        {
            return await _db.Libros
                .AsNoTracking()
                .Include(l => l.Tematicas)
                .OrderBy(l => l.Titulo)
                .ToListAsync();
        }
    }
}