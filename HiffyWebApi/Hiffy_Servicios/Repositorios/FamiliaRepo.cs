using Hiffy_Datos;
using Hiffy_Entidades.Entidades;
using Hiffy_Servicios.Common;
using Hiffy_Servicios.Dtos;
using Hiffy_Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiffy_Servicios.Repositorios
{
    public class FamiliaRepo : IFamilia
    {

        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public FamiliaRepo(AppDbContext context, IEmailService emailService, IConfiguration configuration)
        {
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<OperationResult> CrearUsuario(CrearUsuarioDto usuarioRegistro)
        {
            if (usuarioRegistro.Correo == null || usuarioRegistro.Contraseña == null)
            {
                return new OperationResult(false, "Favor suministrar las credenciales.");
            }

            var usuarioExiste = await _context.Usuario.Where(x => x.Correo == usuarioRegistro.Correo).FirstOrDefaultAsync();

            if (usuarioExiste != null)
            {


                return new OperationResult(false, "El correo ya está en uso.");
            }


            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //var usuarioPadre = await _context.Rol.Where(x => x.EsTutor).FirstOrDefaultAsync();
                    //REGISTRO EL PADRE COMO USUARIO NUEVO
                    var usuario = new Usuario
                    {
                        Nombre = usuarioRegistro.Nombre,

                        IdRol = usuarioRegistro.IdRol,
                        Correo = usuarioRegistro.Correo.ToLower(),
                        FechaRegistro = DateTime.Now,
                        Contraseña = BCrypt.Net.BCrypt.HashPassword(usuarioRegistro.Contraseña),


                        Descripcion = "",
                        Estado = "Activo",
                        Valoracion = null,
                        FechaNacimiento = usuarioRegistro.FechaNacimiento,
                        ///ToDo implementar logica 
                        IdFamilia = usuarioRegistro.IdFamilia,
                        FechaLimiteCodigo = null,
                        CodigoVerificacion = null,




                    };

                    await _context.Usuario.AddAsync(usuario);
                    await _context.SaveChangesAsync();


                    transaction.Commit();


                    return new OperationResult(true, "Resgistro Exitoso.", usuario.IdUsuario);
                }
                catch (Exception ex)
                {
                    // Si ocurre algún error, deshacer la transacción
                    transaction.Rollback();
                    return new OperationResult(false, ex.Message, 0);
                }
            }
        }
    }
}
