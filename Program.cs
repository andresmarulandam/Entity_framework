using Entity_Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity_Framework.Models;

var builder = WebApplication.CreateBuilder(args);

//Conexión base de datos en memoria:
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

// Conexión a sqlserver usando la seguridad de Windows
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("conexionTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
  return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});


app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
  tarea.TareaId = Guid.NewGuid();
  tarea.FechaCreacion = DateTime.Now;
  await dbContext.AddAsync(tarea);

  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
  var tareaActual = dbContext.Tareas.Find(id);

  if (tarea != null)
  {
    tareaActual.CategoriaId = tarea.CategoriaId;
    tareaActual.Titulo = tarea.Titulo;
    tareaActual.PrioridadTarea = tarea.PrioridadTarea;
    tareaActual.Descripcion = tarea.Descripcion;

    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }
  return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
  var tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual != null)
  {
    dbContext.Remove(tareaActual);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }



  return Results.NotFound();
});
app.Run();
