using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearFotoMascotaDTO
    {
        [Required(ErrorMessage = "La foto de la mascota es obligatoria")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string UrlFoto { get; set; }

        [Required(ErrorMessage = "El Nombre de usuario es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; } 
    }
}
