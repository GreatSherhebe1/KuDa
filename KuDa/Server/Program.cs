using KuDa.Server.DBContext;
using KuDa.Server.Repositories;
using KuDa.Server.Services;
using KuDa.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                    };
                });
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connection = builder.Configuration.GetConnectionString("Postgre");
            builder.Services.AddDbContextPool<AppDBContext>(o => o.UseNpgsql(connection));

            // repos
            builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IRepository<Group>, GroupRepository>();
            builder.Services.AddScoped<IRepository<GroupUser>, GroupUserRepository>();
            builder.Services.AddScoped<IRepository<Transaction>, TransactionRepository>();
            builder.Services.AddScoped<IRepository<User>, UserRepository>();

            // services
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<IUserService, UserService>();

            // map
            //builder.Services.AddAutoMapper();

            builder.Services.AddRazorPages();
            //var connection = builder.Configuration.GetConnectionString("Postgre");
            var postgreConnection = builder.Configuration.GetConnectionString("Postgre");
            builder.Services.AddDbContext<PostgreContext>(o => o.UseNpgsql(postgreConnection));

            //var sqliteConnection = builder.Configuration.GetConnectionString("SQLite");
            //builder.Services.AddDbContext<SQLiteContext>(o => o.UseSqlite(sqliteConnection));
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();
            //app.UseEndpoints();

            app.MapControllers();
            app.MapRazorPages();

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
