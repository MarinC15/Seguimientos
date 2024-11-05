using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguimientos.Web.Data.Entities
{
    public class Expense 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public DateTime Date { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string Category { get; set; } = null!;
    }
}
