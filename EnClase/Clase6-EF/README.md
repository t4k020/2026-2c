# Clase 7 - EF 1 a N y N a N
## Qué hicimos
- Agregamos relacion 1 a N Tematica con Juguete
- Agregamos relacion N a N Sucursal con Juguete

## Tarea

Agrega una nueva entidad llamada `Libro` y entidad `Categoria` N a N en el namespace `Clase6.EF.Entidades` con las siguientes propiedades:

- `int Id` (clave primaria)
- `string Titulo`
- `string Autor`
- `int AnioPublicacion`



# Clase6 - EF Core y Razor Pages

## Resumen de la solución

Este repositorio contiene un proyecto Razor Pages / ASP.NET Core (.NET 9) que demuestra el uso de Entity Framework Core y la gestión de migraciones de base de datos.

## Qué hicimos

- Creamos `JugueteriaDbContext` y las entidades del dominio.
- Generamos migraciones con `dotnet ef migrations add` (paso en tiempo de diseño) para capturar cambios del modelo.
- Aplicamos las migraciones al iniciar la aplicación usando `db.Database.Migrate()` en `Program.cs` para mantener el esquema actualizado.
- Analizamos `db.SaveChanges()`:
  - `db.SaveChanges()` persiste los cambios de las entidades rastreadas por el `DbContext`.
  - `dotnet ef migrations add` solo lee el modelo y genera archivos de migración; no llama a `SaveChanges()`.
  - `db.Database.Migrate()` aplica las migraciones al esquema; no persiste entidades a menos que las agregues y llames `SaveChanges()`.

## Tarea

Agrega una nueva entidad llamada `Libro` en el namespace `Clase6.EF.Entidades` con las siguientes propiedades:

- `int Id` (clave primaria)
- `string Titulo`
- `string Autor`
- `int AnioPublicacion`

### Pasos sugeridos


**Cómo utilizar este repositorio:**

1. **Forkea este repositorio:**
   * Haz clic en el botón "Fork" en la esquina superior derecha.
   * Esto creará una copia personal del repositorio en tu cuenta.

2. **Clona tu fork:**
3. **Realiza tus tareas:**
   ** Crea una nueva rama para cada tarea
   ** Recuerda:** Incluye comentarios concisos y claros en cada commit para explicar los cambios realizados.

4. **Envía un Pull Request (PR):**
   * Una vez que hayas terminado tu tarea, envía un Pull Request a este repositorio original.
   * En la descripción del PR, explica qué has hecho y por qué.
   * Revisa cuidadosamente tu PR antes de enviarlo para asegurarte de que todo funciona correctamente.

**Recomendaciones:**

* **Comentarios claros:** Siempre incluye comentarios en tu código para explicar tu lógica y decisiones.
* **Pruebas:** Realiza pruebas exhaustivas para asegurarte de que tu código funciona como se espera.
* **Revisión de código:** Revisa cuidadosamente los PRs de tus compañeros y ofrece feedback constructivo.
* **Convenciones de estilo:** Sigue las convenciones de estilo de programación recomendadas para el lenguaje que estamos utilizando.
* **No subas archivos innecesarios:** Evita subir archivos grandes o innecesarios que puedan comprometer el tamaño del repositorio.

1. Crear el archivo `Clase6.EF.Entidades\Libro.cs` con la clase `Libro`.
2. Registrar `public DbSet<Libro> Libros { get; set; }` en `JugueteriaDbContext`.
3. Ejecutar:
   - `dotnet ef migrations add AddLibro`
   - `dotnet ef database update`
   O iniciar la app si en `Program.cs` se ejecuta `db.Database.Migrate()` al inicio.

## Ejemplo de la clase `Libro`

```csharp
// Clase6.EF.Entidades\Libro.cs
using System;

namespace Clase6.EF.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int AnoPublicacion { get; set; }
    }
}