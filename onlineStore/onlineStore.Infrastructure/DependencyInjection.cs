using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using onlineStore.Application.IRepositories;
using onlineStore.Application.IServices;
using onlineStore.Infrastructure.ApplicationContext;
using onlineStore.Infrastructure.Services;
using onlineStore.Infrastructure.Repositories;

namespace onlineStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(@"Server=db;Database=master;User=sa;Password=30051986;");

            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); ;

            return services;
        }
        
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IItemsService, ItemsService>();

            return services;
        }
    }
}