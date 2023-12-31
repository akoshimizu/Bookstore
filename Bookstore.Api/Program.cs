using Bookstore.Api.Hypermedia.Enricher;
using Bookstore.Api.Hypermedia.Filters;
using Bookstore.Api.ValueObject.Mapping;
using Bookstore.Infra.IoC;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
    {
        c.EnableAnnotations();
        c.SwaggerDoc("v1", new OpenApiInfo 
        {
           Version = "v1",
           Title = "Book Registration",
           Contact = new OpenApiContact
           {
            Name = "Anderson Alves Koshimizu",
            Email = "anderson_koshimizu@hotmail.com"
           }
        });
        string xmlPath = Path.Combine("wwwroot", "api-doc.xml");
        c.IncludeXmlComments(xmlPath);
    });

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

builder.Services.AddAutoMapper(typeof(BookVOProfile));
builder.Services.AddSingleton(filterOptions);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi","{controller=values}/{id?}");
            });

app.MapControllers();

app.Run();