using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoCrud.AutorModel.Model;

namespace ProyectoCrud.AutorConfig.Conf;
public class AutorConfiguracion : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.HasKey(e => e.idAutor);
        builder.Property(e => e.nombre).IsRequired().HasMaxLength(100);
        builder.Property(e => e.nacionalidad).IsRequired().HasMaxLength(100);
        builder.Property(e => e.fecha_nacimiento).IsRequired().HasMaxLength(100);
    }
}