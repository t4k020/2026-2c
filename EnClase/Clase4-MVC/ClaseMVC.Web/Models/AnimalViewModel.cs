using System.ComponentModel.DataAnnotations;

namespace ClaseMVC.Web.Models;

public class AnimalViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la raza es obligatorio.")]
    [StringLength(200)]
    public string Raza { get; set; } = string.Empty;

    [Range(0.1, 1000, ErrorMessage = "El peso debe estar entre 0.1 y 1000 kg.")]
    public double Peso { get; set; }

    [Range(1, 200, ErrorMessage = "La edad estimada debe estar entre 1 y 200 años.")]
    public int EdadEstimada { get; set; }

    [Display(Name = "En extinción")]
    public bool EnExtincion { get; set; }

    [Required(ErrorMessage = "La URL de la imagen es obligatoria.")]
    [StringLength(2000, MinimumLength = 1, ErrorMessage = "La URL de la imagen debe tener entre 1 y 2000 caracteres.")]
    public string ImagenUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "El habitat es obligatorio")]
    [StringLength(200, ErrorMessage = "El habitat no debe superar los 200 caracteres.")]
    public string Habitat { get; set; } = string.Empty;

    [Range(0.01, 1000)]
    public double? Largo { get; set; }

    [StringLength(500)]
    public string? SignificadoNombre { get; set; }

    // Propiedades específicas de la UI (no están en la entidad)
    public int NacimientosUltimoMes { get; set; }
    public int CantidadEjemplares { get; set; }
}
