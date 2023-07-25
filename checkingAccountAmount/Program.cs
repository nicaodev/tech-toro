using checkingAccountAmount.Infra.IoC;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

DependencyInjection.AddDependencyInjection(builder.Services, builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Checking Account Amount - Toro Investimentos.",
        Version = "v1",
        Description = "TORO-002 - Eu, como investidor, gostaria de visualizar meu saldo, meus investimentos e meu patrimônio total na Toro.",
        Contact = new OpenApiContact
        {
            Name = "Nicolas Pereira",
            Url = new Uri("https://www.linkedin.com/in/nasp/")
        },
    });

    var xmlFilenameSummary = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilenameSummary));
});

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(option => option.AllowAnyOrigin()); ;
app.UseAuthorization();

app.MapControllers();

app.Run();