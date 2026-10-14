using System.ComponentModel.DataAnnotations;
namespace _2C_2026_CLASE3.Entidades;

public class Animal
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La raza es obligatoria")]
    [Display(Name = "Raza")]
    public string Raza { get; set; }
    
    [Range(0.1, 100000, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
    [Display(Name = "Peso (en kg)")]
    public double Peso { get; set; }

    [Range(0, 200, ErrorMessage = "La edad estimada debe estar entre {1} y {2}")]
    [Display(Name = "Edad Estimada")]
    public int EdadEstimada { get; set; }

    [Display(Name = "En Extinción")]
    public bool EnExtincion { get; set; }
    
    [StringLength(2000, ErrorMessage = "La url no puede superar los 2000 caracteres")]
    [Required(ErrorMessage = "La url es obligatoria")]
    [Display(Name = "Url Imagen")]
    public string UrlImagen { get; set; }

    [StringLength(80, ErrorMessage = "El {0} no puede superar los 80 caracteres")]
    [Required(ErrorMessage = "El {0} es obligatorio")]
    [Display(Name = "Hábitat")]
    public string Habitat { get; set; }

    [StringLength(80, ErrorMessage = "El lugar de origen no puede superar los 80 caracteres")]
    [Required(ErrorMessage = "El lugar de origen es obligatorio")]
    [Display(Name = "Lugar de Origen")]
    public string LugarOrigen { get; set; }

    [Range(0, 100000, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
    [Display(Name = "Largo (en cm)")]
    public int? Largo { get; set; }

    [Range(0, 100000, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
    [Display(Name = "Alto (en cm)")]
    public int? Alto { get; set; }

}
