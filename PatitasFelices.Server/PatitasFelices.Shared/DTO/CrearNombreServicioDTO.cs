using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearNombreServicioDTO
    {
        [Required(ErrorMessage = "El nombre del servicio es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string NombreDeServicio { get; set; }

        [Required(ErrorMessage = "El precio del servicio es obligatorio")]
        public decimal Precio { get; set; }
    }
}
