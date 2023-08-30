using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
           builder.ToTable("persona");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasMaxLength(3);

            builder.Property(e => e.NombrePersona)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(e => e.Genero)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdGeneroFk);

            builder.HasOne(e => e.Ciudad)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdCiudadFk);

            builder.HasOne(e => e.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdTipoPerFk);
        }
    }
}