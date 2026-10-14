using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6.EF.Entidades
{
    public class GutendexRespuesta
    {
        public List<GutendexLibro> Results { get; set; } = new();
    }

    public class GutendexLibro
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<GutendexAutor> Authors { get; set; } = new();
        public List<string> Bookshelves { get; set; } = new();
        public Dictionary<string, string> Formats { get; set; } = new();
    }

    public class GutendexAutor
    {
        public string Name { get; set; } = string.Empty;
    }

    public record LibroDescargado(string Titulo, string Autor, string Texto, List<string> Tematicas);
}
