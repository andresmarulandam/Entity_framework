using System.ComponentModel.DataAnnotations;

namespace Entity_Framework.Models;

public class Categoria
{
  // con los data notacion o atributos como key se sabe que categoriaId sera la primary key
  // [Key]


  //El tipo de dato Guid es un 'Identificador global único' el cual nos retorna un dato unico, ejemplo : 5a7939fd-59de-44bd-a092-f5d8434584de
  public Guid CategoriaId { get; set; }
  // [Required]
  // [MaxLength(150)]
  public string Nombre { get; set; }
  public string Descripcion { get; set; }

  public int Peso { get; set; }
  public virtual ICollection<Tarea> Tareas { get; set; }
}
