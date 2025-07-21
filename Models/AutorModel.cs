using ProyectoCrud.LibroModel.Model;

namespace ProyectoCrud.AutorModel.Model;

public class Autor
{
    public int idAutor { get; set; }
    public required string nombre { get; set; }
    public required string nacionalidad { get; set; }
    public required string fecha_nacimiento { get; set; }

    public ICollection<Libro>? Libros { get; set; }
}
