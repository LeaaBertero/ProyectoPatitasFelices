using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Server.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexion con la base de datos
#region ConnectionString
builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
#endregion

#region Servicios de las interfaz de las entidades
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITransaccionRepositorio, TransaccionRepositorio>();
builder.Services.AddScoped<ITarjetaRepositorio, TarjetaRepositorio>();
builder.Services.AddScoped<IServicioRepositorio, ServicioRepositorio>();
builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
builder.Services.AddScoped<IPrecioServicioRepositorio, PrecioServicioRepositorio>();
builder.Services.AddScoped<IPrecioRepositorio, PrecioRepositorio>();
builder.Services.AddScoped<INombreServicioRepositorio, NombreServicioRepositorio>();
builder.Services.AddScoped<IMensajeRepositorio, MensajeRepositorio>();
builder.Services.AddScoped<IMascotaRepositorio, MascotaRepositorio>();
builder.Services.AddScoped<IFotoUsuarioRepositorio, FotoUsuarioRepositorio>();
builder.Services.AddScoped<IFotoMascotaRepositiorio, FotoMascotaRepositorio>();
builder.Services.AddScoped<IFotoRepositorio, FotoRepositorio>();
builder.Services.AddScoped<IComentarioRepositorio, ComentarioRepositorio>();
#endregion

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
