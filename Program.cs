using DotnetOrderAI.Data;
using DotnetOrderAI.Repository;
using DotnetOrderAI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;
using System.Reflection;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using DotnetOrderAI.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<dbContext>(options =>
options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(optopns =>
{
    optopns.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Projeto de conclus�o Challenge FIAP 2024 - 2� Semestre",
        Description = "API criada pelo time Solution Developers para o app chamado OrderAI",
        Contact = new OpenApiContact
        {
            Name = "Solution Developers",
            Email = "solutiondevelopersteam@gmail.com",
        },
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    optopns.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile("authapp.json")
});

builder.Services.AddHttpClient<IAuthService, AuthService>((sp, httpClient) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    httpClient.BaseAddress = new Uri(configuration["Authentication:TokenUri"]!);
});


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

app.Run();