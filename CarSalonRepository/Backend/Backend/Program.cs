using Backend.Repositories;
using Backend.Services;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDatabesServices(connectionString!);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ISalonRepository, SalonRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ISalonService, SalonService>();
            builder.Services.AddScoped<IDTOConversionService, DTOConversionService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var allowedSpecificOrigins = "allowedOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: allowedSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:5173")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials();

                                  });
            });

            var app = builder.Build();

            app.UseCors(allowedSpecificOrigins);

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
