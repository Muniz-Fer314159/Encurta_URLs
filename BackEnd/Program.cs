
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MongoDbConfig>(
    builder.Configuration.GetSection("MongoDBSettings")
);

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();
