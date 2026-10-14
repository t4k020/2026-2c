using ClaseMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClaseMVC.Logica;

public interface IFloresServicios
{

    List<Flor> Listar();
    void Agregar(Flor flor);
    void Actualizar(Flor flor);
    void Eliminar(int id);
    Flor? ObtenerPorId(int id);

}

public class FloresServicios : IFloresServicios
{
    private static List<Flor> listaFlores;

    public FloresServicios()
    {
        listaFlores = new List<Flor>() 
        { 
            new Flor() { Id = 1, nombre = "Rosa", descripcion = "Clásica y fragante, ideal para arreglos románticos.", imgUrl = "img/flores/rosa.webp"}, 
            new Flor() { Id = 2, nombre = "Tulipán", descripcion = "Sencillo y elegante, disponible en muchos colores.", imgUrl = "img/flores/tulipan.webp" }, 
            new Flor() { Id = 3, nombre = "Girasol", descripcion = "Grande y luminoso, simboliza energía y alegría.", imgUrl = "img/flores/girasol.jpg" }, 
            new Flor() { Id = 4, nombre = "Lirio", descripcion = "Flor sofisticada con aroma suave y pétalos llamativos.", imgUrl = "img/flores/lirio.webp" }, 
            new Flor() { Id = 5, nombre = "Orquídea", descripcion = "Exótica y delicada, perfecta para regalos refinados.", imgUrl = "img/flores/orquidea.jpg" }, 
            new Flor() { Id = 6, nombre = "Lycoris", descripcion = "Flor exótica con pétalos delicados y aroma intenso.", imgUrl = "img/flores/lycoris.jpeg" }
        };
    }

    public void Actualizar(Flor flor)
    {
        var florDB = listaFlores.Find(f => f.Id == flor.Id);
        if (florDB != null)
        {
            florDB.nombre = flor.nombre;
            florDB.descripcion = flor.descripcion;
            florDB.imgUrl = flor.imgUrl;
        }
    }

    public void Agregar(Flor flor)
    {
        int nuevoId = listaFlores.Count > 0 ? listaFlores.Max(a => a.Id) + 1 : 1;
        flor.Id = nuevoId;
        listaFlores.Add(flor);
    }

    public void Eliminar(int id)
    {
        var florDB = listaFlores.Find(f => f.Id == id);
        if (florDB != null)
        {
            listaFlores.Remove(florDB);
        }
    }

    public List<Flor> Listar()
    {
        return listaFlores;
    }

    public Flor? ObtenerPorId(int id)
    {
        var florDB = listaFlores.Find(f => f.Id == id); 
        return florDB;
    }
}
