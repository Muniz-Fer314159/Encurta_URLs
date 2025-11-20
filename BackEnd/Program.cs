using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do MongoDB
builder.Services.Configure<MongoDbConfig>(
    builder.Configuration.GetSection("MongoDb")
);
builder.Services.AddSingleton<URLRepository>();

// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddScoped<UrlsServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "URL Shortener API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Swagger sempre disponível
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "URL Shortener API v1");
    c.RoutePrefix = string.Empty;

    c.InjectStylesheet("/swagger-custom.css");
    c.InjectJavascript("/swagger-custom.js");
});

app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
