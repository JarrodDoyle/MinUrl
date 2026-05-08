using MinUrl.Server.Db;
using MinUrl.Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LinkDbContext>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.Run();