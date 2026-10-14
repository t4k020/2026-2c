using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6.EF.Entidades
{
    public class Pagina
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int LibroId { get; set; }
        public string Contenido { get; set; }
        public Libro Libro { get; set; }

    }
}
