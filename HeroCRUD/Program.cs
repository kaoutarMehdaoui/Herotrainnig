using Application.Data;
using Application.Repository;
using HeroCRUD.Mapper;
using Infrastructure.contrat;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("stingConnection");
// Add services to the container.
builder.Services.AddDbContext<MyContext>(c => c.UseSqlServer(connection));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IGenerique<>),typeof(GeneriqueImp<>));
builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
