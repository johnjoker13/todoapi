using Api.Common;
using Api.DependencyInjection;
using Application.DependencyInjection;
using FluentValidation;
using Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentantion()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseMiddleware<GlobalErrorHandler>();

app.MapControllers();

ValidatorOptions.Global.LanguageManager.Enabled = false;

app.Run();
