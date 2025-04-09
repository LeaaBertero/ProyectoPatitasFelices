using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearPrecioServicioDTO
    {
        [Required(ErrorMessage = "El nombre del servicio es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string NombreServicio { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public decimal Precio { get; set; }
    }
}
