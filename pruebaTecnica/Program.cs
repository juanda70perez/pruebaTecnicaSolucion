using pruebaTecnica.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// añadir politicas Cors para que el front consuma la api
builder.Services.AddCors(p => p.AddPolicy("corspolicy",build =>
{
    build.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//correr las politicas cors
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
var programa = new programa();

var recursividad = new Recursividad();
recursividad.main();
app.Run();
