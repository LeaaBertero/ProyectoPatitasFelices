using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearReservaDTO
    {
        [Required(ErrorMessage = "La fecha de inicio de la reserva es obligatoria")]
        public DateTime FechaHoraInicio { get; set; }

        [Required(ErrorMessage = "La fecha de finalización de la reserva es obligatoria")]
        public DateTime FechaHoraFin { get; set; }

        [Required(ErrorMessage = "El estado de la reserva es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}")]
        public string EstadoReserva { get; set; }
    }
}
