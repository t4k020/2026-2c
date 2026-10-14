Ejercicio: Eliminar alimento y mostrar mensaje con TempData

Objetivo
- Practicar la integración entre la capa de servicio y el controlador en una aplicación ASP.NET Core MVC.
- Usar TempData para comunicar al usuario cuál fue el último alimento eliminado.

Descripción
- En la vista Alimento/Lista.cshtml se debe mostrar, si existe, el contenido de TempData["Mensaje"] en la parte superior.
- En la columna "Eliminar" de la lista hay un enlace que llama al endpoint Eliminar del controlador Alimentos.
- Al eliminar un alimento se debe setear TempData["Mensaje"] con el texto que indique Nombre, Calorías y Peso del alimento eliminado. Ejemplo:
  "Último alimento eliminado: Manzana - 52 kcal - 150 g"

Requisitos implementados en esta solución
1. Entidad Alimento (Id, Nombre, Calorias, Peso) agregada en el proyecto ClaseMVC.Entidades.
2. Servicio IAlimentosServicios / AlimentosServicios en ClaseMVC.Logica con métodos Listar, Agregar, Actualizar, ObtenerPorId y Eliminar. El método Eliminar devuelve el objeto eliminado.
3. Controlador AlimentosController con acciones Lista() y Eliminar(id). La acción Eliminar setea TempData["Mensaje"] con los datos del alimento eliminado y redirige a Lista.
4. Vista Views/Alimento/Lista.cshtml que muestra TempData["Mensaje"] si existe y la tabla con los alimentos y un enlace para eliminar.

Instrucciones para el alumno (si se pide que lo complete manualmente)
1. Abrir la vista Views/Alimento/Lista.cshtml.
2. Añadir el bloque que muestra TempData["Mensaje"] si no está presente.
3. En el controlador, implementar la lógica de Eliminar: obtener el alimento por id, eliminarlo desde el servicio y setear TempData con el mensaje requerido.

Notas
- En esta implementación el enlace Eliminar usa una petición GET para simplificar el ejercicio (igual que las otras controllers del proyecto). En producción se recomienda usar POST con antiforgery para operaciones destructivas.
