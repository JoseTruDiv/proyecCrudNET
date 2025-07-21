using ProyectoCrud.Data.Libreria;
using ProyectoCrud.UsuarioModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProyectoCrud.Seeds.UsuarioSemillas; 

public static class UsuarioSeeds 
{
    public static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<LibreriaDbContext>();

            await context.Database.MigrateAsync();

            if (!await context.Usuarios.AnyAsync())
            {
                Console.WriteLine("Sembrando usuarios...");
                await context.Usuarios.AddRangeAsync(
                    new Usuario {
                        idUser = 1,
                        nombre = "Ana García",
                        direccion = "Calle Falsa 123, Madrid",
                        telefono = "600112233",
                        email = "ana.garcia@example.com",
                        fecha_reg = "2023-01-15"
                    },
                    new Usuario {
                        idUser = 2,
                        nombre = "Juan Pérez",
                        direccion = "Av. Siempre Viva 45, Barcelona",
                        telefono = "611223344",
                        email = "juan.perez@example.com",
                        fecha_reg = "2023-02-20"
                    },
                    new Usuario {
                        idUser = 3,
                        nombre = "María López",
                        direccion = "Plaza Mayor 1, Valencia",
                        telefono = "622334455",
                        email = "maria.lopez@example.com",
                        fecha_reg = "2023-03-10"
                    },
                    new Usuario {
                        idUser = 4,
                        nombre = "Pedro Ruiz",
                        direccion = "Gran Vía 10, Sevilla",
                        telefono = "633445566",
                        email = "pedro.ruiz@example.com",
                        fecha_reg = "2023-04-05"
                    },
                    new Usuario {
                        idUser = 5,
                        nombre = "Laura Fernández",
                        direccion = "Calle del Sol 5, Málaga",
                        telefono = "644556677",
                        email = "laura.fernandez@example.com",
                        fecha_reg = "2023-05-12"
                    },
                    new Usuario {
                        idUser = 6,
                        nombre = "Carlos Sánchez",
                        direccion = "Paseo de Gracia 8, Bilbao",
                        telefono = "655667788",
                        email = "carlos.sanchez@example.com",
                        fecha_reg = "2023-06-01"
                    },
                    new Usuario {
                        idUser = 7,
                        nombre = "Sofía Gómez",
                        direccion = "Ronda de Dalt 20, Zaragoza",
                        telefono = "666778899",
                        email = "sofia.gomez@example.com",
                        fecha_reg = "2023-07-25"
                    },
                    new Usuario {
                        idUser = 8,
                        nombre = "Miguel Martín",
                        direccion = "Calle del Carmen 15, Murcia",
                        telefono = "677889900",
                        email = "miguel.martin@example.com",
                        fecha_reg = "2023-08-08"
                    },
                    new Usuario {
                        idUser = 9,
                        nombre = "Elena Díaz",
                        direccion = "Avenida de América 3, Palma",
                        telefono = "688990011",
                        email = "elena.diaz@example.com",
                        fecha_reg = "2023-09-19"
                    },
                    new Usuario {
                        idUser = 10,
                        nombre = "David Romero",
                        direccion = "Calle Colón 7, Las Palmas",
                        telefono = "699001122",
                        email = "david.romero@example.com",
                        fecha_reg = "2023-10-30"
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