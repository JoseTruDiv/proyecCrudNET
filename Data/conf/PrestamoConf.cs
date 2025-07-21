using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoCrud.PrestamoModel.Model;
using ProyectoCrud.UsuarioModel.Model;
using ProyectoCrud.LibroModel.Model; 

namespace ProyectoCrud.PrestamoConfig.Conf;

public class PrestamoConfiguracion : IEntityTypeConfiguration<Prestamo>
{
    public void Configure(EntityTypeBuilder<Prestamo> builder)
    {
        builder.HasKey(e => e.idPrestamo);

        builder.Property(e => e.fecha_prestamo)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(e => e.fecha_devolucion)
            .IsRequired() 
            .HasMaxLength(100);
        
        builder.Property(e => e.estado)
            .IsRequired()
            .HasConversion<string>(); 

        
        builder.HasOne(p => p.Usuario)     
               .WithMany()                 
               .HasForeignKey(p => p.idUsuario)
               .OnDelete(DeleteBehavior.Restrict); 

        
        builder.HasOne(p => p.Libro)      
               .WithMany()                 
               .HasForeignKey(p => p.idLibro)  
               .OnDelete(DeleteBehavior.Restrict); 
    }
}