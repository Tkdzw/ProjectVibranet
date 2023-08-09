using ManagementSystem.Data.DbContext;
using ManagementSystem.Data.EntityModels;
using ManagementSystem.Services.App_Services;
using ManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ManagementSystemDbContext>(options =>
{
    options.UseMySql("server=localhost; uid=pos_db;pwd=posdb@2016;database=ManagementSystemDb", ServerVersion.Parse("8.0.19-mysql"));
});



builder.Services.AddAutoMapper(typeof(Program)); 

builder.Services.AddTransient<IUserDetailsService, UserDetailsService>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
