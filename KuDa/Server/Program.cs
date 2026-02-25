
using KuDa.Server;
using KuDa.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connection = builder.Configuration.GetConnectionString("Postgre");
            builder.Services.AddDbContextPool<AppDBContext>(o => o.UseNpgsql(connection));

            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<GroupRepository>();
            builder.Services.AddScoped<GroupUserRepository>();
            builder.Services.AddScoped<TransactionRepository>();
            builder.Services.AddScoped<UserRepository>();

            builder.Services.AddRazorPages();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            //app.UseEndpoints();

            app.MapControllers();
            app.MapRazorPages();

            app.Run();
        }
    }
}
