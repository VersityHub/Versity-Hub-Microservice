using Microsoft.EntityFrameworkCore;
using ProductManagementService.Data;
using ProductManagementService.Repository.ProductsRepository;
using ProductManagementService.Repository.ProductsRepository.Interface;
using ProductManagementService.Service.ProductsService;
using ProductManagementService.Service.ProductsService.Interface;

namespace ProductManagementService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            builder.Services.AddDbContext<ProductDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            
            builder.Services.AddSwaggerGen();
            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}