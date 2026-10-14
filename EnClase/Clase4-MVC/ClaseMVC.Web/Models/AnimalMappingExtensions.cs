using ClaseMVC.Entidades;

namespace ClaseMVC.Web.Models;

public static class AnimalMappingExtensions
{
    public static AnimalViewModel ToViewModel(this Animal e)
    {
        if (e == null) return new AnimalViewModel();
        return new AnimalViewModel
        {
            Id = e.Id,
            Raza = e.Raza,
            Peso = e.Peso,
            EdadEstimada = e.EdadEstimada,
            EnExtincion = e.EnExtincion,
            ImagenUrl = e.ImagenUrl,
            Habitat = e.Habitat,
            Largo = e.Largo,
            SignificadoNombre = e.SignificadoNombre
        };
    }

    public static Animal ToEntity(this AnimalViewModel vm)
    {
        return new Animal
        {
            Id = vm.Id,
            Raza = vm.Raza,
            Peso = vm.Peso,
            EdadEstimada = vm.EdadEstimada,
            EnExtincion = vm.EnExtincion,
            ImagenUrl = vm.ImagenUrl ?? string.Empty,
            Habitat = vm.Habitat ?? string.Empty,
            Largo = vm.Largo,
            SignificadoNombre = vm.SignificadoNombre ?? string.Empty
        };
    }
}
