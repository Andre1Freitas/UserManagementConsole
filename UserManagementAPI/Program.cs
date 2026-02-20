using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UserManagementAPI.Interfaces.IUserRepository, UserManagementAPI.Repositories.UserEFRepository>();
builder.Services.AddScoped<UserManagementAPI.Services.UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();  // Comentado por enquanto

app.UseAuthorization();

app.MapControllers();

// Endpoint de teste
app.MapGet("/", () => "UserManagement API is running! 🚀");

app.Run();