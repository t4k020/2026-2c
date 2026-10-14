
using Clase6.EF.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Clase6.EF.Logica;
public interface IJuguetesLogica
{
    void Actualizar(Juguete juguete);
    void Agregar(Juguete juguete);
    void Eliminar(int id);
    List<Juguete> Obtener();
    public Juguete? ObtenerPorId(int id);
}

public class JuguetesLogica : IJuguetesLogica
{
    private readonly JugueteriaDbContext db;
    public JuguetesLogica(JugueteriaDbContext db)
    {
        this.db = db;
    }
    public List<Juguete> Obtener()
    {
        return db.Juguetes.Include(j => j.Tematica).ToList();
    }

    public Juguete? ObtenerPorId(int id)
    {
        return db.Juguetes.Include(j=> j.Sucursales).FirstOrDefault(j => j.Id == id);
    }

    public void Agregar(Juguete juguete)
    {
        db.Juguetes.Add(juguete);
        db.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var juguete = Obtener()
            .FirstOrDefault(j => j.Id == id);
        if (juguete == null)
            return;

        db.Juguetes.Remove(juguete);
        db.SaveChanges();
    }
    public void Actualizar(Juguete juguete)
    {
        db.SaveChanges();
    }

}
