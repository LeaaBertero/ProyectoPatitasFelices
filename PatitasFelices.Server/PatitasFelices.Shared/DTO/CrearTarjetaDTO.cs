using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearTarjetaDTO
    {
        [Required(ErrorMessage = "El número de la tarjeta es obligatorio")]
        [MaxLength(16, ErrorMessage = "Máximo número de caracteres {1}")]
        public string NroTarjeta { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public DateOnly FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El código de seguridad es obligatorio")]
        [MaxLength(4, ErrorMessage = "Máximo número de caracteres {1}")]
        public string CodigoSeguridad { get; set; }
    }
}
