using Application.Data;
using Application.Repository;
using HeroCRUD.Imagestorage;
using HeroCRUD.Mapper;
using Infrastructure.contrat;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("stingConnection");
var path = builder.Configuration.GetSection("FilePathSettings");
// Add services to the container.
builder.Services.AddDbContext<MyContext>(c => c.UseSqlServer(connection));
builder.Services.AddControllers();
builder.Services.Configure<FilePathSettings>(path);

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
app.UseCors(policy =>
policy.WithOrigins("https://localhost:7263", "https://localhost:7263")
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
