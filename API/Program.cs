using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("MeowPolicy", x =>
    {
        x.AllowAnyHeader()
         .AllowAnyMethod()
         .WithOrigins("https://localhost:4200");
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("MeowPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
