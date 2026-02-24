using Filmes.WebAPI.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion")));
//builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
//builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
