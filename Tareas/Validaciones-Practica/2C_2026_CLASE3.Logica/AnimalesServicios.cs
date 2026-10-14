using _2C_2026_CLASE3.Entidades;

namespace _2C_2026_CLASE3.Logica;

public interface IAnimalesServicios
{
    public List<Animal> Listar();
    public Animal? ObtenerPorId(int id);
    void Editar(Animal animal);
    public void Eliminar(int id);

    public void Agregar(Animal animal);
}

public class AnimalesServicios : IAnimalesServicios
{
    private static List<Animal> lista;

    public AnimalesServicios()
    {
        lista = new List<Animal>()
        {
            new Animal() 
            { 
                Id = 1, Raza = "Perro", Peso = 20, EdadEstimada = 10, EnExtincion = false, 
                UrlImagen = "/img/perro.png", Habitat = "Doméstico", LugarOrigen = "Europa", Largo = 100, Alto = 60 
            },
            new Animal() 
            { 
                Id = 2, Raza = "Gato", Peso = 5, EdadEstimada = 15, EnExtincion = false, 
                UrlImagen = "/img/gato.png", Habitat = "Doméstico", LugarOrigen = "Egipto", Largo = 50, Alto = 30 
            },
            new Animal() 
            { 
                Id = 3, Raza = "Tigre", Peso = 200, EdadEstimada = 20, EnExtincion = true, 
                UrlImagen = "/img/tigre.png", Habitat = "Selva", LugarOrigen = "Asia", Largo = 300, Alto = 110 
            },
            new Animal() 
            { 
                Id = 4, Raza = "Elefante", Peso = 5000, EdadEstimada = 70, EnExtincion = true, 
                UrlImagen = "/img/elefante.png", Habitat = "Sabana", LugarOrigen = "África", Largo = 600, Alto = 350 
            }
        };
    }
    public List<Animal> Listar()
    {
        return lista;
    }

    public Animal? ObtenerPorId(int id)
    {
        return lista.FirstOrDefault(a => a.Id == id);
    }

    public void Editar(Animal animal)
    {
        var animalExistente = ObtenerPorId(animal.Id);
        if (animalExistente != null)
        {
            animalExistente.Raza = animal.Raza;
            animalExistente.Peso = animal.Peso;
            animalExistente.EdadEstimada = animal.EdadEstimada;
            animalExistente.EnExtincion = animal.EnExtincion;
            animalExistente.UrlImagen = animal.UrlImagen;
            animalExistente.Habitat = animal.Habitat;
            animalExistente.LugarOrigen = animal.LugarOrigen;
            animalExistente.Largo = animal.Largo;
            animalExistente.Alto = animal.Alto;
        }
    }

    public void Eliminar(int id)
    {
        var animal = ObtenerPorId(id);
        if (animal != null)
        {
            lista.Remove(animal);
        }
    }

    public void Agregar(Animal animal)
    {
        animal.Id = lista.Count == 0 ? 1 : lista.Max(a => a.Id) + 1;
        lista.Add(animal);
    }
}
