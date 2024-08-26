using Hiffy_Servicios.Interfaces;
using Hiffy_Servicios.Repositorios;

namespace HiffyWebApi.Services
{
    public static class RepositorioServices
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            return services.AddScoped<FamiliaRepo>()

                .AddScoped<IEmailService, EmailService>();
        }
    }
}
