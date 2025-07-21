using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoCrud.LibroModel.Model; // Asegúrate de incluir el namespace correcto para tu modelo Libro
using ProyectoCrud.AutorModel.Model; // Asegúrate de incluir el namespace correcto para tu modelo Autor

namespace ProyectoCrud.LibroConfig.Conf;

public class LibroConfiguracion : IEntityTypeConfiguration<Libro>
{
    public void Configure(EntityTypeBuilder<Libro> builder)
    {
        // Configuración de la clave primaria para Libro
        builder.HasKey(e => e.idLibro);

        
        builder.Property(e => e.titulo)
            .IsRequired()      
            .HasMaxLength(255); 

      
        builder.Property(e => e.anio_pub)
            .IsRequired()     
            .HasMaxLength(255); 

       
        builder.Property(e => e.descripcion)
            .IsRequired()      
            .HasMaxLength(255); 

            
        builder.Property(e => e.genero)
            .IsRequired()     
            .HasMaxLength(255);

        // --- Configuración de la relación de clave foránea a Autor ---

        // Un Libro (l) tiene UN Autor (l.Autor)
        builder.HasOne(l => l.Autor)
               // Un Autor (a) tiene MUCHOS Libros (a.Libros)
               .WithMany(a => a.Libros)
               // La clave foránea en la tabla Libros que apunta a Autor es 'idAutor'
               .HasForeignKey(l => l.idAutor)
               // Comportamiento al eliminar: Si se borra un Autor,
               // los Libros asociados a él no se borrarán automáticamente.
               // Esto previene borrados accidentales de Libros.
               .OnDelete(DeleteBehavior.Restrict); 
    }
}