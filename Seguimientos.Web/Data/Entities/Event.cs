using System.ComponentModel.DataAnnotations;

namespace Seguimientos.Web.Data.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string Title { get; set; } = null!;

        [Display(Name = "Hora de inicio")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Hora de finalización")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string Description { get; set; } = null!;

        [Display(Name = "¿Tiene Recordatorio?")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public bool IsReminderSet { get; set; }

        [Display(Name = "Recordatorio")]
        public DateTime? ReminderTime { get; set; }
    }
}
