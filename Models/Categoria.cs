namespace Entity_Framework.Models;

public class Categoria
{
  //El tipo de dato Guid es un 'Identificador global único' el cual nos retorna un dato unico, ejemplo : 5a7939fd-59de-44bd-a092-f5d8434584de
  public Guid CategoriaId { get; set; }
  public string Nombre { get; set; }
  public string Descripcion { get; set; }

  public virtual ICollection<Tarea> Tareas { get; set; }
}
