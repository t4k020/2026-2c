using Clase6.EF.Entidades;

namespace Clase6.EF.Web.Models;

public class SucursalViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public List<JugueteViewModel> Juguetes { get; set; } = new List<JugueteViewModel>();    

    public Sucursal ToEntity()
    {
        return new Sucursal
        {
            Id = this.Id,
            Nombre = this.Nombre,
            Juguetes = this.Juguetes.Select(j => j.ToEntity()).ToList()
        };
    }
    public static SucursalViewModel FromEntity(Sucursal sucursal, bool incluirJuguetes = false)
    {
        return new SucursalViewModel
        {
            Id = sucursal.Id,
            Nombre = sucursal.Nombre,
            Juguetes = incluirJuguetes ? sucursal.Juguetes.Select(j => JugueteViewModel.FromEntity(j, false)).ToList() : new List<JugueteViewModel>()
        };
    }

    public static List<SucursalViewModel> FromEntity(List<Sucursal> sucursales)
    {
        return sucursales.Select(t => FromEntity(t)).ToList();
    }
}
