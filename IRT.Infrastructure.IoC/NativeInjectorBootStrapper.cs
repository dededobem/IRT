using IRT.Application.Interfaces;
using IRT.Application.Services;
using IRT.Domain.Interfaces;
using IRT.Infrastructure.Data;
using IRT.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IRT.Infrastructure.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, string connection)
        {
            services.AddDbContext<IRTDbContext>(options =>
                    options.UseSqlServer(connection));

            services.AddScoped(typeof(INeighborhoodRepository), typeof(NeighborhoodRepository));
            services.AddScoped(typeof(IAppNeighborhood), typeof(AppNeighborhood));

            services.AddScoped(typeof(IDrugstoreRepository), typeof(DrugstoreRepository));
            services.AddScoped(typeof(IAppDrugstore), typeof(AppDrugstore));

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IAppUser), typeof(AppUser));
            
            services.AddScoped(typeof(IAppAuthentication), typeof(AppAuthentication));
        }
    }
}
