using ProyectoCrud.Data.Libreria;
using ProyectoCrud.LibroModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProyectoCrud.Seeds.LibroSemillas; 

public static class LibroSeeds 
{
    public static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<LibreriaDbContext>();

            await context.Database.MigrateAsync();

            if (!await context.Libros.AnyAsync())
            {
                    Console.WriteLine("Sembrando usuarios...");
                    await context.Libros.AddRangeAsync(
 // Libros de Gabriel García Márquez (idAutor = 1)
            new Libro {
                idLibro = 1,
                titulo = "Cien años de soledad",
                anio_pub = "1967", // Changed to string based on config
                descripcion = "Una de las obras más importantes de la literatura latinoamericana y universal.",
                genero = "Realismo mágico",
                idAutor = 1 // Gabriel García Márquez
            },
            new Libro {
                idLibro = 2,
                titulo = "El amor en los tiempos del cólera",
                anio_pub = "1985",
                descripcion = "Una novela sobre el amor incondicional y la vejez.",
                genero = "Novela romántica",
                idAutor = 1 // Gabriel García Márquez
            },

            // Libros de Isabel Allende (idAutor = 2)
            new Libro {
                idLibro = 3,
                titulo = "La casa de los espíritus",
                anio_pub = "1982",
                descripcion = "Saga familiar que mezcla realismo y elementos sobrenaturales.",
                genero = "Realismo mágico",
                idAutor = 2 // Isabel Allende
            },
            new Libro {
                idLibro = 4,
                titulo = "De amor y de sombra",
                anio_pub = "1984",
                descripcion = "Una historia de amor y denuncia social en un país sudamericano sin nombre.",
                genero = "Novela política",
                idAutor = 2 // Isabel Allende
            },

            // Libros de Jorge Luis Borges (idAutor = 3)
            new Libro {
                idLibro = 5,
                titulo = "Ficciones",
                anio_pub = "1944",
                descripcion = "Colección de cuentos que exploran temas filosóficos y metafísicos.",
                genero = "Cuentos filosóficos",
                idAutor = 3 // Jorge Luis Borges
            },

            // Libros de Laura Restrepo (idAutor = 4)
            new Libro {
                idLibro = 6,
                titulo = "Delirio",
                anio_pub = "2004",
                descripcion = "Thriller psicológico que explora la locura y los secretos familiares.",
                genero = "Novela negra",
                idAutor = 4 // Laura Restrepo
            },

            // Libros de Mario Vargas Llosa (idAutor = 5)
            new Libro {
                idLibro = 7,
                titulo = "La ciudad y los perros",
                anio_pub = "1963",
                descripcion = "Retrato de la vida en un colegio militar en Perú.",
                genero = "Novela realista",
                idAutor = 5 // Mario Vargas Llosa
            },

            // Libros de Clarice Lispector (idAutor = 6)
            new Libro {
                idLibro = 8,
                titulo = "La hora de la estrella",
                anio_pub = "1977",
                descripcion = "Una reflexión profunda sobre la existencia y la pobreza a través de una joven.",
                genero = "Novela filosófica",
                idAutor = 6 // Clarice Lispector
            },

            // Libros de Julio Cortázar (idAutor = 7)
            new Libro {
                idLibro = 9,
                titulo = "Rayuela",
                anio_pub = "1963",
                descripcion = "Novela experimental que puede leerse de múltiples maneras.",
                genero = "Novela experimental",
                idAutor = 7 // Julio Cortázar
            },

            // Libros de Elena Garro (idAutor = 8)
            new Libro {
                idLibro = 10,
                titulo = "Los recuerdos del porvenir",
                anio_pub = "1963",
                descripcion = "Novela que combina realismo mágico e historia de México.",
                genero = "Realismo mágico",
                idAutor = 8 // Elena Garro
            },

            // Libros de Carlos Fuentes (idAutor = 9)
            new Libro {
                idLibro = 11,
                titulo = "Aura",
                anio_pub = "1962",
                descripcion = "Una breve novela gótica que explora la identidad y el tiempo.",
                genero = "Novela gótica",
                idAutor = 9 // Carlos Fuentes
            },

            // Libros de Adelaida García Morales (idAutor = 10)
            new Libro {
                idLibro = 12,
                titulo = "El sur",
                anio_pub = "1985",
                descripcion = "Cuento misterioso que explora la difusa línea entre la realidad y la ficción.",
                genero = "Cuento de misterio",
                idAutor = 10 // Adelaida García Morales
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