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

            using(var scope = services.BuildServiceProvider().CreateScope())
            {
                using(var dbContext = scope.ServiceProvider.GetRequiredService<BookstoreDbContext>())
                {
                    if (dbContext.Database.GetPendingMigrations().Any())
                    {
                        dbContext.Database.Migrate();
                    }
                }
            }

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();



            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(AuthorProfile));
            services.AddMemoryCache();
        }
    }
}