using Clase6.EF.Entidades;

namespace Clase6.EF.Web.Models;

public class JugueteViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int EdadRecomendada { get; set; }
    public IEnumerable<Tematica> Tematicas { get; set; } = new List<Tematica>();
    public int TematicaId { get; set; }
    public Tematica? Tematica { get; set; }

    public List<SucursalViewModel> Sucursales { get; set; } = new List<SucursalViewModel>();
    public List<SucursalViewModel> SucursalesTodas { get; set; } = new List<SucursalViewModel>();
    public List<int> SucursalesIds { get; set; } = new List<int>();


    public Juguete ToEntity()
    {
        return new Juguete
        {
            Id = this.Id,
            Nombre = this.Nombre,
            Precio = this.Precio,
            EdadRecomendada = this.EdadRecomendada,
            TematicaId = this.TematicaId
        };
    }

    public static JugueteViewModel FromEntity(Juguete juguete, bool incluirSucursales = false)
    {
        return new JugueteViewModel
        {
            Id = juguete.Id,
            Nombre = juguete.Nombre,
            Precio = juguete.Precio,
            EdadRecomendada = juguete.EdadRecomendada,
            TematicaId = juguete.TematicaId,
            Tematica = juguete.Tematica,
            Sucursales = incluirSucursales ? juguete.Sucursales.Select(s => SucursalViewModel.FromEntity(s, false)).ToList() : new List<SucursalViewModel>()
        };
    }
}
