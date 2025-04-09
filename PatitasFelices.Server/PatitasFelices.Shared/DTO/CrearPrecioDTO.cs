using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.Shared.DTO
{
    public class CrearPrecioDTO
    {
        [Required(ErrorMessage = "El precio por hora es obligatorio")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public decimal PrecioHora { get; set; }

        [Required(ErrorMessage = "El precio por día es obligatorio")]
        public decimal PrecioDia { get; set; }
    }
}
