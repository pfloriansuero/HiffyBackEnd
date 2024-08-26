using Hiffy_Datos.Mapping;
using Hiffy_Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<AreaDelHogarFamilia> AreaDelHogarFamilia { get; set; }
        public virtual DbSet<CalendarioTareas> CalendarioTareas { get; set; }
        public virtual DbSet<ContratoPersonal> ContratoPersonal { get; set; }
        public virtual DbSet<DispositivoFamilia> DispositivoFamilia { get; set; }
        public virtual DbSet<DispositivoInteligente> DispositivoInteligente { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<Imagenes> Imagenes { get; set; }
        public virtual DbSet<LogActividad> LogActividad { get; set; }
        public virtual DbSet<LogError> LogError { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuRol> MenuRol { get; set; }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<RecurrenciaTareas> RecurrenciaTareas { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TareaDomestica> TareaDomestica { get; set; }

        public virtual DbSet<TipoTarea> TipoTarea { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AreaDelHogarFamiliaMap());
            modelBuilder.ApplyConfiguration(new CalendarioTareasMap());
            modelBuilder.ApplyConfiguration(new ContratoPersonalMap());
            modelBuilder.ApplyConfiguration(new DispositivoFamiliaMap());
            modelBuilder.ApplyConfiguration(new DispositivoInteligenteMap());
            modelBuilder.ApplyConfiguration(new FamiliaMap());
            modelBuilder.ApplyConfiguration(new ImagenesMap());
            modelBuilder.ApplyConfiguration(new LogActividadMap());
            modelBuilder.ApplyConfiguration(new LogErrorMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new MenuRolMap());
            modelBuilder.ApplyConfiguration(new NotificacionMap());
            modelBuilder.ApplyConfiguration(new RecurrenciaTareasMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new TareaDomesticaMap());
            modelBuilder.ApplyConfiguration(new TipoTareaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

        }

    }
}
