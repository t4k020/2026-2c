using Clase6.EF.Entidades;

namespace Clase6.EF.Logica;

public interface ITematicaLogica
{
    void Actualizar(Tematica tematica);
    void Agregar(Tematica tematica);
    void Eliminar(int id);
    List<Tematica> Obtener();
    public Tematica? ObtenerPorId(int id);
}
public class TematicaLogica : ITematicaLogica
{
    private readonly JugueteriaDbContext _db;

    public TematicaLogica(JugueteriaDbContext db)
    {
        _db = db;
    }

    //Actualizar
    public void Actualizar(Tematica tematica)
    {
        _db.SaveChanges();
    }

    //Agregar
    public void Agregar(Tematica tematica)
    {
        _db.Tematicas.Add(tematica);
        _db.SaveChanges();
    }

    //Eliminar
    public void Eliminar(int id)
    {
        var tematica = ObtenerPorId(id);
        if (tematica == null)
            return;
        _db.Tematicas.Remove(tematica);
        _db.SaveChanges();
    }

    //Obtener
    public List<Tematica> Obtener()
    {
        return _db.Tematicas.ToList();
    }

    //ObtenerPorId
    public Tematica? ObtenerPorId(int id)
    {
        return _db.Tematicas.FirstOrDefault(t => t.Id == id);
    }
}


