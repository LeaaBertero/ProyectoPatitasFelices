using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearMascotaDTO
    {
        [Required(ErrorMessage = "El Nombre de la mascota es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La raza es obligatoria")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El tamaño es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Tamaño { get; set; }

        [Required(ErrorMessage = "La foto es obligatoria")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Las nececedades son obligatorias")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string NecesidadesEspeciales { get; set; }
    }
}
