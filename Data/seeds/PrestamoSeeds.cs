using ProyectoCrud.Data.Libreria;
using ProyectoCrud.PrestamoModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProyectoCrud.Seeds.PrestamoSemillas; 

public static class PrestamoSeeds 
{
    public static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<LibreriaDbContext>();

            await context.Database.MigrateAsync();

            if (!await context.Prestamos.AnyAsync())
            {
                    Console.WriteLine("Sembrando usuarios...");
                    await context.Prestamos.AddRangeAsync(
            new Prestamo
            {
                idPrestamo = 1,
                fecha_prestamo = "2025-07-01",
                fecha_devolucion = "2025-07-30", // Assuming a planned return date
                estado = EstadoPrestamo.Activo,
                idUsuario = 1, // Assuming Usuario with ID 1 exists
                idLibro = 1    // Assuming Libro with ID 1 exists ("Cien años de soledad")
            },
            // Préstamo 2: Usuario 2, Libro 3 (Activo)
            new Prestamo
            {
                idPrestamo = 2,
                fecha_prestamo = "2025-07-05",
                fecha_devolucion = "2025-08-05",
                estado = EstadoPrestamo.Activo,
                idUsuario = 2, // Assuming Usuario with ID 2 exists
                idLibro = 3    // Assuming Libro with ID 3 exists ("La casa de los espíritus")
            },
            // Préstamo 3: Usuario 1, Libro 5 (Devuelto)
            new Prestamo
            {
                idPrestamo = 3,
                fecha_prestamo = "2025-06-10",
                fecha_devolucion = "2025-06-25",
                estado = EstadoPrestamo.Devuelto,
                idUsuario = 1,
                idLibro = 5    // Assuming Libro with ID 5 exists ("Ficciones")
            },
            // Préstamo 4: Usuario 3, Libro 7 (Activo)
            new Prestamo
            {
                idPrestamo = 4,
                fecha_prestamo = "2025-07-10",
                fecha_devolucion = "2025-08-10",
                estado = EstadoPrestamo.Activo,
                idUsuario = 3, // Assuming Usuario with ID 3 exists
                idLibro = 7    // Assuming Libro with ID 7 exists ("La ciudad y los perros")
            },
            // Préstamo 5: Usuario 2, Libro 9 (Activo)
            new Prestamo
            {
                idPrestamo = 5,
                fecha_prestamo = "2025-07-12",
                fecha_devolucion = "2025-08-12",
                estado = EstadoPrestamo.Activo,
                idUsuario = 2,
                idLibro = 9    // Assuming Libro with ID 9 exists ("Rayuela")
            },
            // Préstamo 6: Usuario 4, Libro 2 (Devuelto)
            new Prestamo
            {
                idPrestamo = 6,
                fecha_prestamo = "2025-05-20",
                fecha_devolucion = "2025-06-15",
                estado = EstadoPrestamo.Devuelto,
                idUsuario = 4, // Assuming Usuario with ID 4 exists
                idLibro = 2    // Assuming Libro with ID 2 exists ("El amor en los tiempos del cólera")
            },
            // Préstamo 7: Usuario 3, Libro 4 (Activo)
            new Prestamo
            {
                idPrestamo = 7,
                fecha_prestamo = "2025-07-15",
                fecha_devolucion = "2025-08-15",
                estado = EstadoPrestamo.Activo,
                idUsuario = 3,
                idLibro = 4    // Assuming Libro with ID 4 exists ("De amor y de sombra")
            },
            // Préstamo 8: Usuario 5, Libro 6 (Activo)
            new Prestamo
            {
                idPrestamo = 8,
                fecha_prestamo = "2025-07-17",
                fecha_devolucion = "2025-08-17",
                estado = EstadoPrestamo.Activo,
                idUsuario = 5, // Assuming Usuario with ID 5 exists
                idLibro = 6    // Assuming Libro with ID 6 exists ("Delirio")
            },
            // Préstamo 9: Usuario 1, Libro 8 (Devuelto)
            new Prestamo
            {
                idPrestamo = 9,
                fecha_prestamo = "2025-06-01",
                fecha_devolucion = "2025-06-10",
                estado = EstadoPrestamo.Devuelto,
                idUsuario = 1,
                idLibro = 8    // Assuming Libro with ID 8 exists ("La hora de la estrella")
            },
            // Préstamo 10: Usuario 4, Libro 10 (Activo)
            new Prestamo
            {
                idPrestamo = 10,
                fecha_prestamo = "2025-07-17",
                fecha_devolucion = "2025-08-17",
                estado = EstadoPrestamo.Activo,
                idUsuario = 4,
                idLibro = 10   // Assuming Libro with ID 10 exists ("Los recuerdos del porvenir")
            }

                      );
                await context.SaveChangesAsync();
                Console.WriteLine("Usuarios sembrados.");
            }
            else
            {
                Console.WriteLine("Los usuarios ya existen en la base de datos.");
            }
        }
    }
}