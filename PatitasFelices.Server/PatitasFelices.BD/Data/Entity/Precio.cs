using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(PrecioId), Name = "PrecioId_UQ", IsUnique = true)]
    [Index(nameof(PrecioHora), nameof(PrecioDia),
    Name = "PrecioHora_PrecioDia", IsUnique = false)]
    public class Precio : EntityBase
    {
        #region clave primaria
        public int PrecioId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "El precio por hora es obligatorio")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public decimal PrecioHora { get; set; }

        [Required(ErrorMessage = "El precio por día es obligatorio")]
        public decimal PrecioDia { get; set; }
        #endregion
    }
}
