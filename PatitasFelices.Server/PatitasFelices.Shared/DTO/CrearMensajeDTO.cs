using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearMensajeDTO
    {
        [Required(ErrorMessage = "El contenido del mensaje es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string ContenidoMensaje { get; set; }

        [Required(ErrorMessage = "La fecha del mensaje es obligatoria")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public DateTime FechaHoraMensaje { get; set; }
    }
}
