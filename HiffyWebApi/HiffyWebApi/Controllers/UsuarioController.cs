using Hiffy_Datos;
using Hiffy_Entidades.Entidades;
using Hiffy_Servicios.Common;
using Hiffy_Servicios.Dtos;
using Hiffy_Servicios.Repositorios;
using HiffyWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HiffyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly FamiliaRepo _familiaRepositorio;
        private readonly AppDbContext _context;

        public UsuarioController(IConfiguration configuration, AppDbContext context, FamiliaRepo familiaRepo)
        {
            _configuration = configuration;
            _context = context;
            _familiaRepositorio = familiaRepo;
        }

        /// <summary>
        /// Allows creating a user  
        /// </summary>
        /// <param name="userDto">Model that receives data for the user</param> 
        [HttpPost("create-user")]
        public async Task<OperationResult> CrearUsuarioPadre(CrearUsuarioDto userDto)
        {
            try
            {
                var usuario = await _familiaRepositorio.CrearUsuario(userDto);

                return usuario;

            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }

        }

        /// <summary>
        /// Allows accessing the user's account and returning the token.
        /// </summary>
        /// <param name="correo">User's email</param>
        /// <param name="password">User's email password</param> 
        [HttpPost("login")]
        public async Task<OperationResult> IniciarSesion(string correo, string password)
        {
            try
            {
                var usuario = await _context.Usuario.Where(x => x.Correo.Trim().ToLower() == correo.Trim().ToLower()).FirstOrDefaultAsync();

                if (usuario == null) return new OperationResult(false, "Usuario o contraseña invalidos");

                // Lógica para generar el código aleatorio


                if (!BCrypt.Net.BCrypt.Verify(password, usuario.Contraseña))
                {
                    return new OperationResult(false, "Contraseña Incorrecta");
                }

                var token = CreateToken(usuario);

                var userDto = new UsuarioDto
                {
                    Correo = usuario.Correo,
                    Nombre = usuario.Nombre,
                    IdRol = usuario.IdRol,
                    IdFamilia = usuario.IdFamilia

                };

                return new OperationResult(true, "Exito al iniciar sesión", userDto, token);

            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }

        }

        private string CreateToken(Usuario user)
        {
            List<Claim> claims = new List<Claim> {
          new Claim(ClaimsService.Correo, user.Correo),
          new Claim(ClaimsService.UsuaNombre, user.Nombre),
          new Claim(ClaimsService.UsuarioId, user.IdUsuario.ToString()),
          new Claim(ClaimsService.RolId, user.IdRol.ToString()),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(45),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
