using ProyectoCrud.UsuarioModel.Model;
using ProyectoCrud.LibroModel.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoCrud.PrestamoModel.Model;

// Renamed to clarify it's the state of the loan, not the book
public enum EstadoPrestamo
{
    Activo,   // The loan is currently active
    Devuelto  // The loan has been returned
}

public class Prestamo
{
    public int idPrestamo { get; set; }
    public required string fecha_prestamo { get; set; }
    public required string fecha_devolucion { get; set; } 

    [NotMapped]
    public EstadoPrestamo estado { get; set; } = EstadoPrestamo.Activo; 

    public int idUsuario { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public int idLibro { get; set; }
    public Libro Libro { get; set; } = null!; 
}