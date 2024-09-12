using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework.Models;

public class Tarea
{
  [Key]
  //El tipo de dato Guid es un 'Identificador global único' el cual nos retorna un dato unico, ejemplo : 5a7939fd-59de-44bd-a092-f5d8434584de  
  public Guid TareaId { get; set; }
  [ForeignKey("CategoriaId")]
  public Guid CategoriaId { get; set; }
  [Required]
  [MaxLength(200)]
  public string Titulo { get; set; }
  public string Descripcion { get; set; }
  public Prioridad PrioridadTarea { get; set; }
  public DateTime FechaCreacion { get; set; }
  public virtual Categoria Categoria { get; set; }
  [NotMapped]
  public string Resumen { get; set; }
}

public enum Prioridad
{
  Baja,
  Media,
  Alta
}
