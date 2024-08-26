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
    public class AreaDelHogarFamiliaMap : IEntityTypeConfiguration<AreaDelHogarFamilia>
    {
        public void Configure(EntityTypeBuilder<AreaDelHogarFamilia> builder)
        {
            builder.ToTable("AreaDelHogarFamilia")
                .HasKey(x => x.IdAreaFamilia);
        }
    }
}
