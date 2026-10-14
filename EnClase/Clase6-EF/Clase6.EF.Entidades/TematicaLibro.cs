
namespace Clase6.EF.Entidades
{
    public class TematicaLibro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
