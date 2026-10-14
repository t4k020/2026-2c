namespace Clase6.EF.Entidades;

public class Sucursal
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Juguete> Juguetes { get; set; } = new List<Juguete>();
}
