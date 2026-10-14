using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparador.Entidad;

namespace Comparador.ServicioLocal;

public interface IComerciosServicio
{
    List<Comercio> ObtenerComercios();
}

public class ComerciosServicio : IComerciosServicio
{
    private List<Comercio> _comercios;
    public ComerciosServicio()
    {
        _comercios = new List<Comercio>();
        _comercios.Add(new Comercio { Id = 1, nombre = "Garbarino" });
        _comercios.Add(new Comercio { Id = 2, nombre = "Fravega" });
        _comercios.Add(new Comercio { Id = 3, nombre = "Naldo" });
        _comercios.Add(new Comercio { Id = 4, nombre = "Mercado Libre" });
    }
    public List<Comercio> ObtenerComercios()
    {
        return _comercios;
    }
}