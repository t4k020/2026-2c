using ClaseMVC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClaseMVC.Entidades
{
    public class Comercio
    {
        [Required(ErrorMessage = "Nombre del comercio obligatorio") ]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [MinLength(1,ErrorMessage = "debe haber al menos un producto registrado")]
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
