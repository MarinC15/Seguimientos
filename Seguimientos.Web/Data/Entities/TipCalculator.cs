using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguimientos.Web.Data.Entities
{
    public class TipCalculator
    {
        [Key]
        public int Id { get; set; } 

        [Display(Name = "Monto de la factura")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal BillAmount { get; set; }

        [Display(Name = "Porcentaje de propina")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TipPercentage { get; set; }

        [Display(Name = "Cantidad de propina")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TipAmount { get; set; }

        [Display(Name = "Monto total")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalAmount { get; set; }
        
        public void CalculateTip()
        {
            TipAmount = BillAmount * (TipPercentage / 100);
            TotalAmount = BillAmount + TipAmount;
        }
    }

}
