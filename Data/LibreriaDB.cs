using Microsoft.EntityFrameworkCore;
using ProyectoCrud.UsuarioModel.Model;
using ProyectoCrud.UsuarioConfig.Conf;
using ProyectoCrud.AutorModel.Model;
using ProyectoCrud.AutorConfig.Conf;
using ProyectoCrud.LibroModel.Model;
using ProyectoCrud.LibroConfig.Conf;
using ProyectoCrud.PrestamoModel.Model;
using ProyectoCrud.PrestamoConfig.Conf;

namespace ProyectoCrud.Data.Libreria;

public class LibreriaDbContext : DbContext
{
    public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
        modelBuilder.ApplyConfiguration(new AutorConfiguracion());
        modelBuilder.ApplyConfiguration(new LibroConfiguracion());
        modelBuilder.ApplyConfiguration(new PrestamoConfiguracion());
    }
}

