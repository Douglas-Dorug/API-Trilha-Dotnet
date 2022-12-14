using ModuloAPI.Context;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string stringConexao = builder.Configuration.GetConnectionString("ConexaoPadrao");

//Conexão com o banco de dados MySQL
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao)));


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

app.UseAuthorization();

app.MapControllers();

app.Run();
