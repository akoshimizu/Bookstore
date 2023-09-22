using Bookstore.Application.Interfaces;
using Bookstore.Application.Services;
using Bookstore.Application.Services.Mappings;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Bookstore.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infra.IoC
{
    public static class InfrastructureServices
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BookstoreDbContext>(options => 
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(BookstoreDbContext).Assembly.FullName)));

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddAutoMapper(typeof(BookProfile));
            services.AddMemoryCache();  
        }
    }
}