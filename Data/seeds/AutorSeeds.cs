using ProyectoCrud.Data.Libreria;
using ProyectoCrud.AutorModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProyectoCrud.Seeds.AutorSemillas; 

public static class AutorSeeds 
{
    public static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<LibreriaDbContext>();

            await context.Database.MigrateAsync();

            if (!await context.Autores.AnyAsync())
            {
                Console.WriteLine("Sembrando usuarios...");
                await context.Autores.AddRangeAsync(
                    new Autor { idAutor = 1, nombre = "Gabriel García Márquez", nacionalidad = "Colombiana", fecha_nacimiento = "06/03/1927" },
                    new Autor { idAutor = 2, nombre = "Isabel Allende", nacionalidad = "Chilena", fecha_nacimiento = "02/08/1942" },
                    new Autor { idAutor = 3, nombre = "Jorge Luis Borges", nacionalidad = "Argentina", fecha_nacimiento = "24/08/1899" },
                    new Autor { idAutor = 4, nombre = "Laura Restrepo", nacionalidad = "Colombiana", fecha_nacimiento = "21/01/1950" },
                    new Autor { idAutor = 5, nombre = "Mario Vargas Llosa", nacionalidad = "Peruana", fecha_nacimiento = "28/03/1936" },
                    new Autor { idAutor = 6, nombre = "Clarice Lispector", nacionalidad = "Brasileña", fecha_nacimiento = "10/12/1920" },
                    new Autor { idAutor = 7, nombre = "Julio Cortázar", nacionalidad = "Argentina", fecha_nacimiento = "26/08/1914" },
                    new Autor { idAutor = 8, nombre = "Elena Garro", nacionalidad = "Mexicana", fecha_nacimiento = "11/12/1916" },
                    new Autor { idAutor = 9, nombre = "Carlos Fuentes", nacionalidad = "Mexicana", fecha_nacimiento = "11/11/1928" },
                    new Autor { idAutor = 10, nombre = "Adelaida García Morales", nacionalidad = "Española", fecha_nacimiento = "17/01/1948" }
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