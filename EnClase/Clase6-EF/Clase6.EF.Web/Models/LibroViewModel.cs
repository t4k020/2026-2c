namespace Clase6.EF.Web.Models
{
    public class LibroViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public List<string> Tematicas { get; set; } = new();
    }

    public class BuscarLibroViewModel
    {
        public string? Titulo { get; set; }
        public string? Mensaje { get; set; }
        public List<LibroViewModel> Libros { get; set; } = new();
    }

    public class LeerLibroViewModel
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Numero { get; set; }
        public int TotalPaginas { get; set; }
        public string Contenido { get; set; } = string.Empty;
    }
}
