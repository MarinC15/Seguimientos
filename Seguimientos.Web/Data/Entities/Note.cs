using System.ComponentModel.DataAnnotations;

namespace Seguimientos.Web.Data.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string Title { get; set; } = null!;

        [Display(Name = "Contenido")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string Content { get; set; } = null!;

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string Category { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
