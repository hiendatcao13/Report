
using MVC2.BUS;

namespace MVC2.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISinhVienService, SinhVienService>();
            services.AddScoped<ILopService, LopService>();
        }
    }
}
