using System.Collections.Generic;

namespace ClaseMVC.Web.Services;

public interface IRecientesService
{
    List<int> ObtenerRecientes();
    void AgregarReciente(int id);
    void LimpiarRecientes();
}
