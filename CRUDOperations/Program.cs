using Infrastructure;
using Persistence.Contexts;
using Presentation;

namespace CRUDOperations;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region services

        // Add services to the container.
        builder.Services.AddDatabaseFromPersistence(UserContext.ConnectionString);
        builder.Services.AddRepositories();

        builder.Services.AddAuthorizations();
        builder.Services.AddControllersFromPresentation();
        builder.Services.AddSwaggerWithAuthorization();

        #endregion

        var app = builder.Build();

        #region Middlewares


        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUIWithAuthorization();
        }

        //Calls migration to create or update the database
        app.UseMigrations();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        #endregion

        app.Run();
    }
}
