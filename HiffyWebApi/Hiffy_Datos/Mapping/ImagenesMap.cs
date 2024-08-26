using Hiffy_Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Datos.Mapping
{
    public class ImagenesMap : IEntityTypeConfiguration<Imagenes>
    {
        public void Configure(EntityTypeBuilder<Imagenes> builder)
        {
            builder.ToTable("Imagenes")
                .HasKey(x => x.IdImagen);
        }
    }
}
