namespace Clase6.EF.Entidades;

public class Tematica
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Juguete> Juguetes { get; set; } = new List<Juguete>();
}
