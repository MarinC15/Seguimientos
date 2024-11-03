using System.ComponentModel.DataAnnotations;

namespace Segumientos.Web.Data.Entities
{
    public class TaskL
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string? Description { get; set; }

        [Display(Name = "¿Está ompeleto?")]
        public bool IsCompleted { get; set; }
    }
}

