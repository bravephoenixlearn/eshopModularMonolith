using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container

            // Api endpoint services

            // Application use case services

            // Data - Infrastructure services
            string connectionString = configuration.GetConnectionString("eShopDbCon")!;            
            services.AddDbContext<CatalogDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IDataSeeder, CatalogDataSeeder>();

            return services;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline

            // 1. Use Api endpoint services

            // 2. Use Application use case services

            // 3. Data - Infrastructure services
            app.UseMigration<CatalogDbContext>();

            return app;
        }
    }
}
