using APIEproject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<APIEprojectContext>(
    option =>
        option.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            sqlServerOptionsAction: option =>
            {
                option.EnableRetryOnFailure();
            }
            )
        );
builder.Services.AddDbContext<APIEprojectContext>(ServiceLifetime.Transient);

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowOrigin", p =>
    {
        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseCors(
        options => options.WithOrigins("http://localhost:3000").AllowAnyMethod()
    );

app.UseAuthorization();

app.MapControllers();

app.Run();
