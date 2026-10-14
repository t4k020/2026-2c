using ClaseMVC.Entidades;

namespace ClaseMVC.Logica;

public interface IAlimentosServicios
{
    List<Alimento> Listar();
    void Agregar(Alimento alimento);
    void Actualizar(Alimento alimento);
    Alimento? ObtenerPorId(int id);
    Alimento? Eliminar(int id);
}

public class AlimentosServicios : IAlimentosServicios
{
    private static List<Alimento> listaAlimentos;

    public AlimentosServicios()
    {
        listaAlimentos = new List<Alimento>()
        {
            new Alimento() { Id = 1, Nombre = "Manzana", Calorias = 52, Peso = 150 },
            new Alimento() { Id = 2, Nombre = "Banana", Calorias = 96, Peso = 120 },
            new Alimento() { Id = 3, Nombre = "Tostada", Calorias = 75, Peso = 30 }
        };
    }

    public void Agregar(Alimento alimento)
    {
        int nuevoId = listaAlimentos.Count > 0 ? listaAlimentos.Max(a => a.Id) + 1 : 1;
        alimento.Id = nuevoId;
        listaAlimentos.Add(alimento);
    }

    public void Actualizar(Alimento alimento)
    {
        var db = listaAlimentos.Find(a => a.Id == alimento.Id);
        if (db != null)
        {
            db.Nombre = alimento.Nombre;
            db.Calorias = alimento.Calorias;
            db.Peso = alimento.Peso;
        }
    }

    public Alimento? Eliminar(int id)
    {
        var db = listaAlimentos.Find(a => a.Id == id);
        if (db != null)
        {
            listaAlimentos.Remove(db);
            return db;
        }
        return null;
    }

    public List<Alimento> Listar()
    {
        return listaAlimentos;
    }

    public Alimento? ObtenerPorId(int id)
    {
        return listaAlimentos.Find(a => a.Id == id);
    }
}
