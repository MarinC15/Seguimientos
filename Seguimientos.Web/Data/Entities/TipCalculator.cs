using System.ComponentModel.DataAnnotations;

namespace Seguimientos.Web.Data.Entities
{
    public class TipCalculator
    {
        [Key]
        public int Id { get; set; } 

        [Display(Name = "Monto de la factura")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public decimal BillAmount { get; set; }

        [Display(Name = "Porcentaje de propina")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public decimal TipPercentage { get; set; }

        [Display(Name = "Cantidad de propina")]
        public decimal TipAmount { get; set; }

        [Display(Name = "Monto total")]
        public decimal TotalAmount { get; set; }
        
        public void CalculateTip()
        {
            TipAmount = BillAmount * (TipPercentage / 100);
            TotalAmount = BillAmount + TipAmount;
        }
    }

}
