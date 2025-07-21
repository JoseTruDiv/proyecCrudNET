using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ProyectoCrud.Data.Libreria;
using ProyectoCrud.Seeds.UsuarioSemillas;
using ProyectoCrud.Seeds.AutorSemillas;
using ProyectoCrud.Seeds.LibroSemillas;
using ProyectoCrud.Seeds.PrestamoSemillas;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Añadir los servicios de autorización
builder.Services.AddAuthorization();

// Registrar el DbContext con la inyección de dependencias
builder.Services.AddDbContext<LibreriaDbContext>(options =>
    options.UseMySql(connectionString,
                     ServerVersion.AutoDetect(connectionString))
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- AÑADE ESTE BLOQUE DE CÓDIGO AQUÍ ---
// Esto asegura que las semillas se ejecuten al iniciar la aplicación
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<LibreriaDbContext>();

        // ¡IMPORTANTE! Esto eliminará la base de datos si existe. 
        // Úsalo SOLO en entornos de desarrollo.
        await context.Database.EnsureDeletedAsync();
        Console.WriteLine("Base de datos eliminada (si existía).");


        // Aplica migraciones y siembra los datos
        await UsuarioSeeds.SeedDataAsync(services);
        await AutorSeeds.SeedDataAsync(services);
        await LibroSeeds.SeedDataAsync(services);
        await PrestamoSeeds.SeedDataAsync(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al sembrar la base de datos.");
        // O simplemente Console.WriteLine para depuración si no tienes ILogger configurado
        Console.WriteLine($"Error al sembrar la base de datos: {ex.Message}");
    }
}
// --- FIN DEL BLOQUE A AÑADIR ---


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
