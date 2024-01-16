using Tangerpay.Api.Services;
using Tangerpay.Api.Ports;
using Tangerpay.Data.DataContexts;
using Tangerpay.Data.RepositoryAdapters;
using Microsoft.EntityFrameworkCore;

namespace Tangerpay.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:3000")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            // ioc
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "Test"));
            services.AddScoped<DataSeeder>();

            services.AddScoped<IContactsService, ContactsService>();
            services.AddScoped<IContactsRepository, ContactsRepository>();

            services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Tangerpay APIs");
                });
            }

            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");

            // put last so header configs like CORS or Cookies etc can fire
            app.UseEndpoints(endpoints => endpoints.MapControllers().AllowAnonymous());

            // seed data
            using (var scope = app.Services.CreateScope())
            {
                var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

                dataSeeder.Seed();
            }

            // run app
            app.Run();
        }
    }
}