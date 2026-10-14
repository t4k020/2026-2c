using _2C_2026_CLASE3.Logica;

// ============================================================================
//  Program.cs - Punto de entrada de la aplicación web.
//
//  En la clase 1 teníamos "static void Main(...)". Acá no lo ves porque
//  .NET usa "top-level statements": el compilador genera el Main por vos
//  y este archivo ES el cuerpo del Main.
// ============================================================================

// 1) El "builder" arma la aplicación: lee appsettings.json, configura logging,
//    y nos deja registrar servicios (inyección de dependencias).
var builder = WebApplication.CreateBuilder(args);

// 2) Registramos los servicios que la app va a usar.
//    AddControllersWithViews() habilita el patrón MVC: Controllers + Views (Razor).
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IAnimalesServicios, AnimalesServicios>();

// 3) Con los servicios ya registrados, construimos la app.
var app = builder.Build();

app.UseRequestLocalization("en-US");

// 4) Configuramos el "pipeline" HTTP: cada request pasa por estos middlewares
//    EN ORDEN, de arriba hacia abajo.
if (!app.Environment.IsDevelopment())
{
    // En producción, si hay una excepción no controlada, redirige a /Home/Error.
    app.UseExceptionHandler("/Home/Error");
    // HSTS: le dice al navegador que use siempre HTTPS (por defecto 30 días).
    app.UseHsts();
}

app.UseHttpsRedirection();   // http://  ->  https://
app.UseRouting();            // Decide qué controller/action atiende cada URL

app.UseAuthorization();      // Chequea permisos (por ahora no hay usuarios, no hace nada)

app.MapStaticAssets();       // Sirve los archivos de wwwroot/ (css, js, imágenes)

// 5) Ruta por defecto. La URL se interpreta como /{controller}/{action}/{id}
//    Ejemplos:
//      /                ->  HomeController.Index()
//      /Home/Privacy    ->  HomeController.Privacy()
//      /Animales/Ver/3  ->  AnimalesController.Ver(3)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Animales}/{action=Index}/{id?}")
    .WithStaticAssets();

// 6) Arranca el servidor web (Kestrel) y se queda escuchando requests.
app.Run();
