using MinUrl.Server.Db;
using MinUrl.Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LinkDbContext>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors(options => options.AddPolicy("ReactDev",
    policy => policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod())
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.Run();