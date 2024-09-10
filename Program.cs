var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello!");

app.MapPost("/login", (minimal_api.DTOs.LoginDTO loginDTO) =>
{
  if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
    return Results.Ok("Login efetuado com sucesso!");
  else
   return Results.Unauthorized();
});

app.Run();


