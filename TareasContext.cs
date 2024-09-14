using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework;

public class TareasContext : DbContext
{
  public DbSet<Categoria> Categorias { get; set; }
  public DbSet<Tarea> Tareas { get; set; }

  public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Categoria> categoriasInit = new List<Categoria>();
    categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("8ef288f6-469f-4a31-8304-acca032d3fa4"), Nombre = "Actividades pendientes", Peso = 20 });
    categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("0310a074-0396-40ce-938e-6cea671585b0"), Nombre = "Actividades personales", Peso = 50 });

    modelBuilder.Entity<Categoria>(categoria =>
    {
      categoria.ToTable("Categoria");
      categoria.HasKey(p => p.CategoriaId);
      categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(p => p.Descripcion).IsRequired(false);
      categoria.Property(p => p.Peso);
      categoria.HasData(categoriasInit);
    });


    List<Tarea> tareasInit = new List<Tarea>();

    tareasInit.Add(new Tarea() { TareaId = Guid.Parse("621fefe4-ef23-47b6-8003-c673dde56ec3"), CategoriaId = Guid.Parse("8ef288f6-469f-4a31-8304-acca032d3fa4"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios", FechaCreacion = DateTime.Now });
    tareasInit.Add(new Tarea() { TareaId = Guid.Parse("89fdf87c-11a7-4da2-bb50-6b5a5f6a9eda"), CategoriaId = Guid.Parse("0310a074-0396-40ce-938e-6cea671585b0"), PrioridadTarea = Prioridad.Baja, Titulo = "Pelicula", FechaCreacion = DateTime.Now });

    modelBuilder.Entity<Tarea>(tarea =>
    {
      tarea.ToTable("Tarea");
      tarea.HasKey(p => p.TareaId);
      tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
      tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
      tarea.Property(p => p.Descripcion).IsRequired(false);
      tarea.Property(p => p.PrioridadTarea);
      tarea.Property(p => p.FechaCreacion);
      tarea.Ignore(p => p.Resumen);
      tarea.HasData(tareasInit);
    });
  }


}

