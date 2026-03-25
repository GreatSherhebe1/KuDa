using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;

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

            //var connection = builder.Configuration.GetConnectionString("Postgre");
            var postgreConnection = builder.Configuration.GetConnectionString("Postgre");
            builder.Services.AddDbContext<PostgreContext>(o => o.UseNpgsql(postgreConnection));

            var sqliteConnection = builder.Configuration.GetConnectionString("SQLite");
            builder.Services.AddDbContext<SQLiteContext>(o => o.UseSqlite(sqliteConnection));
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

            app.MapGet("/ping", () => "pong!");
            app.MapGet("/testdb", async (SQLiteContext dbContext) =>
            {
                try
                {
                    var canConnect = await dbContext.Database.CanConnectAsync();
                    return canConnect ? "Подключение к базе данных успешно!" : "Не удалось подключиться к базе данных.";
                }
                catch (Exception ex)
                {
                    return $"Ошибка подключения: {ex.Message}";
                }
            });

            app.Run();
        }
    }
}
