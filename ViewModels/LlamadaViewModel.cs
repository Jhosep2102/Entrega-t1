using System.ComponentModel.DataAnnotations;

namespace ENTREGA_T1.ViewModels
{
    public class LlamadaViewModel
    {
        [Required(ErrorMessage = "ingrese los minutos")]
        [Range(1, 100000, ErrorMessage = "los minutos deben ser mayores a cero")]
        [Display(Name = "Minutos")]
        public int? Minutos { get; set; }

        public int MinutosAdicionales { get; set; }

        public decimal CostoBase { get; set; }

        public decimal CostoAdicional { get; set; }

        public decimal Total { get; set; }

        public bool Calculado { get; set; }

        public void Calcular()
        {
            int minutos = Minutos ?? 0;
            CostoBase = 10;
            MinutosAdicionales = minutos > 5 ? minutos - 5 : 0;
            CostoAdicional = MinutosAdicionales * 2;
            Total = CostoBase + CostoAdicional;
            Calculado = true;
        }
    }
}
