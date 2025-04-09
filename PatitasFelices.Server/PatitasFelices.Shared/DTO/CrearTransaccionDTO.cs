using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearTransaccionDTO
    {
        [Required(ErrorMessage = "El monto es obligatorio")]
        //[MaxLength(12, ErrorMessage = "Máximo número de caracteres {1}")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}")]
        public string MetodoPago { get; set; }
    }
}
