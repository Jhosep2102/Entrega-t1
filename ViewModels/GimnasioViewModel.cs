using System.ComponentModel.DataAnnotations;

namespace ENTREGA_T1.ViewModels
{
    public class GimnasioViewModel
    {
        [Required(ErrorMessage = "ingrese la edad")]
        [Range(1, 120, ErrorMessage = "la edad debe estar entre 1 y 120")]
        [Display(Name = "Edad")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "ingrese los meses")]
        [Range(1, 120, ErrorMessage = "los meses deben estar entre 1 y 120")]
        [Display(Name = "Meses contratados")]
        public int? Meses { get; set; }

        public decimal TarifaBase { get; set; }

        public decimal Subtotal { get; set; }

        public int PorcentajeDescuento { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public bool Calculado { get; set; }

        public void Calcular()
        {
            int edad = Edad ?? 0;
            int meses = Meses ?? 0;

            if (edad < 18)
            {
                TarifaBase = 20;
            }
            else if (edad <= 59)
            {
                TarifaBase = 35;
            }
            else
            {
                TarifaBase = 25;
            }

            PorcentajeDescuento = meses switch
            {
                3 => 5,
                6 => 10,
                12 => 20,
                _ => 0
            };

            Subtotal = TarifaBase * meses;
            Descuento = Subtotal * PorcentajeDescuento / 100;
            Total = Subtotal - Descuento;
            Calculado = true;
        }
    }
}
