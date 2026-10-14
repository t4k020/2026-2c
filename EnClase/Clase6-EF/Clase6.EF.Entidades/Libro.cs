using Clase6.EF.Entidades;

namespace Clase6.EF.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }
        public List<TematicaLibro> Tematicas { get; set; }
        public List<Pagina> Paginas { get; set; }
    }
}
