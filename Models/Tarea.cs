namespace Entity_Framework.Models;

public class Tarea
{

  //El tipo de dato Guid es un 'Identificador global único' el cual nos retorna un dato unico, ejemplo : 5a7939fd-59de-44bd-a092-f5d8434584de  public Guid TareaId { get; set; }
  public Guid CategoriaId { get; set; }
  public string Titulo { get; set; }
  public string Descripcion { get; set; }
  public Prioridad PrioridadTarea { get; set; }
  public DateTime FechaCreacion { get; set; }
  public virtual Categoria Categoria { get; set; }
}

public enum Prioridad
{
  Baja,
  Media,
  Alta
}
