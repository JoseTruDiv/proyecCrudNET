using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Data.Libreria;
using ProyectoCrud.UsuarioModel.Model;
using System;
using System.Threading.Tasks;


namespace ProyectoCrud.DelUsuariosController.Controller;

[ApiController]
[Route("delUsuario")]
public class DelUsuariosController : ControllerBase
{
    private readonly LibreriaDbContext _context;

    public DelUsuariosController(LibreriaDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
            {
                return NotFound($"No se encontró ningún usuario con el ID: {id}.");
            }

        try
        {
            // 3. Marca el usuario para ser eliminado del contexto
            _context.Usuarios.Remove(usuario);

            // 4. Guarda los cambios en la base de datos de forma asíncrona
            await _context.SaveChangesAsync();

            // 5. Retorna una respuesta de éxito (NoContent para DELETE exitoso sin contenido de respuesta)
            return Ok($"Usuario con id {id}, eliminado con éxito."); // Código 204
        }
        catch (DbUpdateException ex)
        {
            // Captura errores específicos de la base de datos durante la eliminación
            Console.WriteLine($"Error de base de datos al eliminar usuario con ID {id}: {ex.Message}");
            return StatusCode(500, $"Error interno del servidor al eliminar el usuario: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Captura cualquier otra excepción inesperada
            Console.WriteLine($"Error inesperado al eliminar usuario con ID {id}: {ex.Message}");
            return StatusCode(500, $"Ocurrió un error inesperado: {ex.Message}");
        }
    }
}