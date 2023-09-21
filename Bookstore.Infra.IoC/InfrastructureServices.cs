using Bookstore.Application.Interfaces;
using Bookstore.Application.Services;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infra.IoC
{
    public class InfrastructureServices
    {
        public static void AddInfrastructure(IServiceCollection service)
        {
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IBookRepository, BookRepository>();
        }
    }
}