# Clase 6 - MVC: ViewModels y Session (Tarea práctica)

## Resumen de lo visto en clase

- Separación de capas: no exponer las entidades del dominio directamente en las vistas web.
- ViewModel: clase específica para la capa web con DataAnnotations para validación y propiedades propias de UI.
- Mapeo manual entre Entidad <-> ViewModel (extensiones `.ToViewModel()` / `.ToEntity()`).
- Session en ASP.NET Core: habilitar `AddDistributedMemoryCache()`/`AddSession()` y `app.UseSession()`; usar `ISession` para guardar objetos (serializar con JSON).
- Extensiones de sesión: `SetObject`/`GetObject` para serializar/deserializar objetos usando `System.Text.Json`.
- Servicio de aplicación (Recientes): encapsular la lógica de lectura/escritura a Session en un servicio inyectable (`IRecientesService` / `RecientesService`) en lugar de manipular Session en el controller.
- Tests unitarios: cubrir la lógica de servicios (`RecientesService`) con un `FakeSession`.

## Objetivo de la tarea

Crear una pequeña funcionalidad usando la misma idea trabajada en clase, pero aplicándola sobre una entidad `Flor`:

- Añadir un ViewModel específico para la UI (`FlorViewModel`) y los mapeos manuales.
- Implementar la posibilidad de marcar/desmarcar una flor como "Favorita".
- Guardar la lista de favoritas en la Session (un servicio `IFavoritosService` que encapsule la lógica de Session).
- Mostrar en la vista Index cuál(es) son las flores favoritas y permitir marcar/desmarcar desde la lista.

## Requisitos mínimos (entregable)

1. Entidad `Flor` (puede vivir en el proyecto de entidades o en la carpeta `Tareas/.../Entities` durante la práctica).
2. `FlorViewModel` con DataAnnotations y propiedades sólo de UI si es necesario.
3. Extensiones de mapeo: `ToViewModel()` y `ToEntity()`.
4. Servicio `IFavoritosService` y una implementación `FavoritosService` que use Session para almacenar la lista de ids favoritos (sin duplicados, fácil de agregar/remover, límite opcional).
5. Cambios en el Controller de flores (p. ej. `FloresController`) que:
   - Use ViewModel en acciones GET/POST.
   - Inyecte `IFavoritosService` y exponga la información de favoritos a la vista (por ejemplo `ViewBag.Favoritos` o parte del ViewModel de Index).
   - Proporcione endpoints/acciones para marcar y desmarcar favoritos (pueden ser POST o GET según preferencia didáctica).
6. En la vista Index:
   - Mostrar la lista de flores y para cada una un control (botón o link) para marcar/desmarcar favorita.
   - Indicar visualmente cuál es favorita (por ejemplo con un icono ★ o clase CSS diferente).
7. (Opcional) Tests unitarios para `FavoritosService` similares a los de `RecientesService`.

## Pistas / pasos sugeridos

1. Crear `Flor` con propiedades básicas: Id, Nombre, Color, ImagenUrl, Descripcion.
2. Crear `FlorViewModel` con anotaciones y propiedades UI (por ejemplo `EsFavorita` si querés incluir ese dato en el ViewModel).
3. Mapeos:
   - `Flor.ToViewModel()` mapeará a `FlorViewModel`.
   - `FlorViewModel.ToEntity()` mapeará a `Flor`.
4. Implementar `FavoritosService`:
   - Métodos: `List<int> ObtenerFavoritos()`, `void AgregarFavorito(int id)`, `void QuitarFavorito(int id)`, `void LimpiarFavoritos()`.
   - Usar `ISession` y `SessionExtensions.SetObject/GetObject` (o usar `ISession.SetString`/`GetString` y `JsonSerializer` manualmente).
5. Inyectar `IFavoritosService` en el Controller de flores.
   - En Index: obtener todas las flores, mapear a ViewModel y marcar `EsFavorita = favoritos.Contains(id)`.
   - Acciones: `MarcarFavorito(int id)` y `QuitarFavorito(int id)` que actualicen el servicio y redirijan al Index.
6. Vistas: usar `asp-for` con el ViewModel; en Index usar un botón que haga POST a `MarcarFavorito`/`QuitarFavorito`.
7. Registrar servicios en `Program.cs`:
   - `builder.Services.AddDistributedMemoryCache();` y `builder.Services.AddSession();`
   - `builder.Services.AddHttpContextAccessor();`
   - `builder.Services.AddScoped<IFavoritosService, FavoritosService>();`
8. Pruebas (opcional): crear un `FakeSession` y tests xUnit para `FavoritosService`.

## Criterios de aceptación

- El proyecto compila.
- Desde la vista Index el usuario puede marcar y desmarcar flores como favoritas.
- Las favoritas se conservan durante la sesión (si cierro el navegador y la sesión expira, desaparecen — ese comportamiento es aceptable).
- El código usa un ViewModel para la UI y mapeos manuales.
- La lógica de Session está encapsulada en `FavoritosService` (no manipular `HttpContext.Session` directamente desde el Controller).

## Material de apoyo / snippets

- Ejemplo mínimo de entidad `Flor`:

```csharp
public class Flor
{
	public int Id { get; set; }
	public string Nombre { get; set; }
	public string Color { get; set; }
	public string ImagenUrl { get; set; }
	public string? Descripcion { get; set; }
}
```

- Ejemplo mínimo de ViewModel `FlorViewModel`:

```csharp
public class FlorViewModel
{
	public int Id { get; set; }
	[Required]
	public string Nombre { get; set; }
	public string Color { get; set; }
	public string ImagenUrl { get; set; }
	public bool EsFavorita { get; set; }
}
```

- Firma sugerida de `IFavoritosService`:

```csharp
public interface IFavoritosService
{
	List<int> ObtenerFavoritos();
	void AgregarFavorito(int id);
	void QuitarFavorito(int id);
	void LimpiarFavoritos();
}
```

## Entrega

- Crear un branch con tus cambios (ej.: `tarea/favoritos-flor`).
- Subir el código al repositorio.
- Añadir screenshots o GIFs que muestren marcar/desmarcar en funcionamiento.


# Clase 5 — Práctica MVC - Validaciones - Pasaje de datos

Resumen
- Aplicación de ejemplo para practicar ASP.NET Core MVC (Razor Views) con el modelo `Animal`.
- Temas: `ViewBag`, `TempData`, validaciones con DataAnnotations y extensión del modelo.
Qué se vio en clase
- `ViewBag`: pasar datos simples desde el controlador a la vista (ej.: `ViewBag.NacimientosUltimoMes`).
- `TempData`: pasar mensajes entre requests (ej.: mostrar aleatoriamente un aviso en `Index`).
- Validaciones: atributos en el modelo (`[Required]`, `[Range]`, `[StringLength]`) y uso de `ModelState.IsValid` en POST.
- Manejo correcto de `checkbox` en formularios (input hidden + checkbox o `asp-for`).

Tarea (entregar)
1) ViewBag
  - En `AnimalesController.GET Agregar` setear `ViewBag.NacimientosUltimoMes = new Random().Next(0, 20);`.
  - En la vista `Agregar` mostrar ese número en un panel informativo.

2) TempData
  - En `AnimalesController.Index` generar aleatoriamente (ej. 30% de probabilidad) un mensaje:
    `TempData["Alerta"] = $"Durante el último año la raza {raza} redujo su población en {porcentaje}%";`
  - En la vista `Index` mostrar `TempData["Alerta"]` si existe (alert Bootstrap), se debe consumir en la siguiente petición.

3) Validaciones
  - Usar `DataAnnotations` en `ClaseMVC.Entidades\Animal`.
  - En los métodos `POST` de `Agregar`/`Editar` comprobar `ModelState.IsValid`. Si no es válido, reasignar `ViewBag` y `return View(model)` para mostrar errores.

4) Nuevos campos simples para `Animal`
  - Sugeridos (añadir en `ClaseMVC.Entidades\Animal`):
    - `public string Habitat { get; set; }` — `[Required, StringLength(200)]`
    - `public double? Largo { get; set; }` — `[Range(0.01, 1000)]` (metros) — opcional (`double?`)
    - `public string SignificadoNombre { get; set; }` — `[StringLength(500)]`
  - Actualizar vistas `Agregar`/`Editar` para incluirlos y `AnimalesServicios` con datos de ejemplo.

Criterios de aceptación
- `Agregar` muestra `ViewBag.NacimientosUltimoMes` en la vista.
- `Index` puede mostrar aleatoriamente `TempData["Alerta"]` y este desaparece al recargar.
- Las validaciones se muestran en las vistas y el `ModelState` evita persistir datos inválidos.
- La aplicación compila y los servicios de ejemplo contienen valores para los nuevos campos.

Snippets útiles
- Pasar ViewBag en controller:
```csharp
ViewBag.NacimientosUltimoMes = new Random().Next(0, 20);
```
- Generar TempData en `Index`:
```csharp
if (new Random().NextDouble() < 0.3)
{
    var raza = "Tigre"; // ejemplo o elegir desde la lista
    var porcentaje = new Random().Next(1, 50);
    TempData["Alerta"] = $"Durante el último año la raza {raza} redujo su población en {porcentaje}%";
}
```
- Checkbox en la vista (tag helper):
```html
<input asp-for="EnExtincion" class="form-check-input" />
```

Notas
- Para formularios más complejos se recomienda crear un ViewModel fuertemente tipado en lugar de usar `ViewBag`.
- Si quieres, puedo aplicar los cambios sugeridos (añadir propiedades en `Animal.cs`, actualizar vistas y `AnimalesServicios`).


# Clase 4 - MVC - Animales C#

## Descripción

Esta solución contiene la implementación de un ABM de Animales usando MVC y capas de Entidades y Logica

## Tarea

**Utilizar el ejemplo de la clase anterior que ya tenemos en sharepoint, y agregarle el proyecto MVC, ya que tenemos entidades y servicios implementados.

## Intrucciones
- Hacer un fork de este repositorio
- Crear Pull Request contra el repositorio original
---

¡Buena suerte con la nueva tarea!