using Microsoft.EntityFrameworkCore;
using minimal_api.DTOs;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")));
});

// Adiciona serviços necessários
var app = builder.Build();

// Configura o pipeline de requisições
app.UseRouting();

app.MapGet("/", () => "Hello!");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login efetuado com sucesso!");
    else
        return Results.Unauthorized();
});

app.Run();