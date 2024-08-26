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
    public class CalendarioTareasMap : IEntityTypeConfiguration<CalendarioTareas>
    {
        public void Configure(EntityTypeBuilder<CalendarioTareas> builder)
        {
            builder.ToTable("CalendarioTareas")
                .HasKey(x => x.IdCalendarioTareas);
        }
    }
}
