using Clase6.EF.Entidades;

namespace Clase6.EF.Web.Models;

public class TematicaViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public List<JugueteViewModel> Juguetes { get; set; } = new List<JugueteViewModel>();    

    public Tematica ToEntity()
    {
        return new Tematica
        {
            Id = this.Id,
            Nombre = this.Nombre,
            Juguetes = this.Juguetes.Select(j => j.ToEntity()).ToList()
        };
    }
    public static TematicaViewModel FromEntity(Tematica tematica)
    {
        return new TematicaViewModel
        {
            Id = tematica.Id,
            Nombre = tematica.Nombre,
            Juguetes = tematica.Juguetes.Select(j => JugueteViewModel.FromEntity(j)).ToList()
        };
    }

    public static List<TematicaViewModel> FromEntity(List<Tematica> tematicas)
    {
        return tematicas.Select(t => FromEntity(t)).ToList();
    }
}
