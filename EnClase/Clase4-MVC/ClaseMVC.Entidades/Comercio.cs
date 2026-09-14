using System;
using System.Collections.Generic;
using System.Text;

namespace ClaseMVC.Entidades
{
    public class Comercio
    {
        public string Nombre { get; set; } = string.Empty;
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
