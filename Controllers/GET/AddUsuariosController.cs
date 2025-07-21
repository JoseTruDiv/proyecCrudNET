using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Data.Libreria;
using ProyectoCrud.UsuarioModel.Model;
using System;
using System.Threading.Tasks;


namespace ProyectoCrud.AddUsuariosController.Controller;

[ApiController]
[Route("addUsuario")]
public class AddUsuariosController : ControllerBase
{
    private readonly LibreriaDbContext _context;

    public AddUsuariosController(LibreriaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> AddUsuarioFromQuery(
        [FromQuery] string nombre,
        [FromQuery] string direccion,
        [FromQuery] string telefono,
        [FromQuery] string email)
    {

        var nuevoUsuario = new Usuario
        {
            nombre = nombre,
            direccion = direccion,
            telefono = telefono,
            email = email,
            fecha_reg = DateTime.Now.ToString("yyyy-MM-dd")
        };

        // 3. Añade el nuevo usuario al DbSet de tu contexto de base de datos
        // Asume que tienes un DbSet<Usuario> llamado 'Usuarios' en tu ApplicationDbContext
        _context.Usuarios.Add(nuevoUsuario);

        // 4. Guarda los cambios en la base de datos de forma asíncrona
        await _context.SaveChangesAsync();
            
        return Ok(nuevoUsuario);
    }
}