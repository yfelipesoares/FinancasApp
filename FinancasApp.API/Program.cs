using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Services;
using FinancasApp.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do CORS para dar permissão ao projeto Blazor
builder.Services.AddCors(
    config => config.AddPolicy("DefaultPolicy", builder => {
        builder.WithOrigins("http://localhost:5039")
               .AllowAnyMethod()
               .AllowAnyHeader();
    })
);

//configuração para injeção de dependência
builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
builder.Services.AddTransient<ICategoriaDomainService, CategoriaDomainService>();
builder.Services.AddTransient<IContaDomainService, ContaDomainService>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IContaRepository, ContaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//registrando a política do CORS
app.UseCors("DefaultPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
