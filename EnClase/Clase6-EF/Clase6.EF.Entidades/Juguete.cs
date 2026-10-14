namespace Clase6.EF.Entidades;

public class Juguete
{
    //usando code first, se asume que la propiedad Id es la clave primaria de la tabla Juguetes
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int EdadRecomendada { get; set; }
    public int TematicaId { get; set; }
    public Tematica Tematica { get; set; }
    public List<Sucursal> Sucursales { get; set; } = new List<Sucursal>();
}

//paso 1
//crear la clase Juguete con sus propiedades

//paso 2
//crear el contexto de base de datos,
//que es la clase que hereda de DbContext
//y contiene las DbSet<T> para cada entidad

//paso 3
//configurar la cadena de conexión a la base de datos

//paso 4
//crear la migración para generar el script SQL que crea la tabla Juguetes

//paso 5
//ejecutar la migración para crear la tabla en la base de datos


