using System.ComponentModel.DataAnnotations;

namespace Seguimientos.Web.Data.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string UserName { get; set; } = null!;

        [Display(Name = "Fecha de Reservación")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public DateTime ReservationDate { get; set; }

        [Display(Name = "Nombre del Servicio")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string ServiceName { get; set; } = null!;

        [Display(Name = "¿Es confirmado?")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public bool IsConfirmed { get; set; }
    }
}
