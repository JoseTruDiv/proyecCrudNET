namespace ProyectoCrud.UsuarioModel.Model;
using ProyectoCrud.PrestamoModel.Model;

public class Usuario
{
    public int idUser { get; set; }
    public required string nombre { get; set; }
    public required string direccion { get; set; }
    public required string telefono { get; set; }
    public required string email { get; set; }
    public required string fecha_reg { get; set; }

    public ICollection<Prestamo>? Prestamos { get; set; }
}
