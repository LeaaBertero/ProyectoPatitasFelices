using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearComentarioDTO
    {
        [Required(ErrorMessage = "El comentario es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string TextoComentario { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public DateOnly FechaPublicacion { get; set; }
    }
}
