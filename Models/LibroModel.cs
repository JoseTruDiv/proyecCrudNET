using ProyectoCrud.AutorModel.Model;
using ProyectoCrud.PrestamoModel.Model;

namespace ProyectoCrud.LibroModel.Model;

public class Libro
{
    public int idLibro { get; set; }
    public required string titulo { get; set; }
    public required string anio_pub { get; set; }
    public required string descripcion { get; set; }
    public required string genero { get; set; }

    public int idAutor { get; set; }

    public Autor Autor { get; set; } = null!;

    public ICollection<Prestamo>? Prestamos { get; set; }
}
