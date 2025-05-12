
using MVC2.DAL;
using MVC2.UnitOfWorks;

namespace MVC2.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISinhVienRepository, SinhVienRepository>();
            services.AddScoped<ILopRepository, LopRepository>();



            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
