using HexaProductCatalog.Application.Services;
using HexaProductCatalog.Domain.Interfaces;
using HexaProductCatalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HexaProductCatalog.Presentation;

public static class DependencyInjection
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddScoped<IProductRepository, InMemoryProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductProxy, ProductProxy>();
        services.AddHttpClient<ProductProxy>();
        return services.BuildServiceProvider();
    }
}