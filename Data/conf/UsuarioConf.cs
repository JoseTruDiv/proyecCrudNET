using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoCrud.UsuarioModel.Model;

namespace ProyectoCrud.UsuarioConfig.Conf;
public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(e => e.idUser);
        builder.Property(e => e.nombre).IsRequired().HasMaxLength(100);
        builder.Property(e => e.direccion).IsRequired().HasMaxLength(100);
        builder.Property(e => e.telefono).IsRequired().HasMaxLength(100);
        builder.Property(e => e.email).IsRequired().HasMaxLength(100);
        builder.Property(e => e.fecha_reg).IsRequired().HasMaxLength(100);
    }
}