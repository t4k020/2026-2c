using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClaseMVC.Entidades
{
    public class Producto
    {
        [Required(ErrorMessage = "Se necesita ingresar un Nombre")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Se necesita ingresar un Valor")]
        [Range(10.01, Double.MaxValue, ErrorMessage = "El precio debe ser mayor a 10.00")]
        public double Precio { get; set; }



    }
}
