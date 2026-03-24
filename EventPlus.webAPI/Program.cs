using Azure.AI.ContentSafety;
using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Repositorie;
using EventPlus.webAPI.Repositories;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;


public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var endpoint = "";
        var apiKey = "";

        var client = new ContentSafetyClient(new Uri(endpoint), new Azure.AzureKeyCredential(apiKey));

        builder.Services.TryAddSingleton(client);

        builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openap
        builder.Services.AddOpenApi();

        //injecao de depedencia
        builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepositor>();
        //injecao de depedencia
        builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
        //injecao de depedencia
        builder.Services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
        //injecao de depedencia 
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        //injecao de depedencia
        builder.Services.AddScoped<IEventoRepository, EventoRepository>();
        //injecao de depedencia
        builder.Services.AddScoped<IPresencaRepository, PresencaRepository>();
        //injecao de depedencia
        builder.Services.AddScoped<IComentarioEventoRepository, ComentarioRepository>();





        builder.Services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = "JwtBearer";
            options.DefaultAuthenticateScheme = "JwtBearer";
        })
        .AddJwtBearer("JwtBearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                //valida quem está solicitando o token
                ValidateIssuer = true,
                //valida quem irá receber o token
                ValidateAudience = true,
                //Valida a expiração do token
                ValidateLifetime = true,
                //Chave de acesso do token
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("events-chave-autenticacao-webapi-dev")),
                //Tempo de expiração do token
                ClockSkew = TimeSpan.FromMinutes(5),
                //nome do issuer (de onde está vindo)
                ValidIssuer = "api_events",
                //nome do audience (para onde ele está indo)
                ValidAudience = "api_events"
            };
        });



        //Adiciona Swagger
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API de eventos",
                Description = "Aplicação para gerenciamento de eventos",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Gustavo Oliveira",
                    Url = new Uri("https://github.com/GOliveira0818")
                },
                License = new OpenApiLicense
                {
                    Name = "Exemplo de licensa",
                    Url = new Uri("https://example.com/license")
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT: "
            });
            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
            });


        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwagger(options => { });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }



        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    

    }
}