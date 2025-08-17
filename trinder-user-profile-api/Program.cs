
using Restaurants.Infrastructure.Extentions;
using System.Threading.Tasks;
using Trinder.UserProfile.Infrastructure.Seeders;

namespace trinder_user_profile_api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            var scoped = app.Services.CreateScope();
            var seeder = scoped.ServiceProvider.GetRequiredService<ITrinderUserProfileSeeder>();
            await seeder.Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
