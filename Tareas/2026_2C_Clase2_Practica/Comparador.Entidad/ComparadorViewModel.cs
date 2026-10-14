using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparador.Entidad;

public class ComparadorViewModel
{
    public List<Comercio>? Comercios { get; set; }
    public List<Producto>? Productos { get; set; }
    public List<Comparador>? Comparaciones { get; set; }
}
