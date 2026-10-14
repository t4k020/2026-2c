using Clase6.EF.Entidades;

namespace Clase6.EF.Logica;

public interface ISucursalLogica
{
    void Actualizar(Sucursal sucursal);
    void Agregar(Sucursal sucursal);
    void Eliminar(int id);
    List<Sucursal> Obtener();
    public Sucursal? ObtenerPorId(int id);
}
public class SucursalLogica : ISucursalLogica
{
    private readonly JugueteriaDbContext _db;

    public SucursalLogica(JugueteriaDbContext db)
    {
        _db = db;
    }

    //Actualizar
    public void Actualizar(Sucursal sucursal)
    {
        _db.SaveChanges();
    }

    //Agregar
    public void Agregar(Sucursal sucursal)
    {
        _db.Sucursales.Add(sucursal);
        _db.SaveChanges();
    }

    //Eliminar
    public void Eliminar(int id)
    {
        var sucursal = ObtenerPorId(id);
        if (sucursal == null)
            return;
        _db.Sucursales.Remove(sucursal);
        _db.SaveChanges();
    }

    //Obtener
    public List<Sucursal> Obtener()
    {
        return _db.Sucursales.ToList();
    }

    //ObtenerPorId
    public Sucursal? ObtenerPorId(int id)
    {
        return _db.Sucursales.FirstOrDefault(s => s.Id == id);
    }
}


