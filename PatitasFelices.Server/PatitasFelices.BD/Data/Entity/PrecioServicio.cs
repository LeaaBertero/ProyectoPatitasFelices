using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(PrecioServicioId), Name = "PrecioServicioId_UQ", IsUnique = true)]
    [Index(nameof(NombreServicio), nameof(Precio),
    Name = "NombreServicio_Precio", IsUnique = false)]
    public class PrecioServicio : EntityBase
    {
        #region clave primaria
        public int PrecioServicioId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "El nombre del servicio es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string NombreServicio { get; set; }
        
        [Required(ErrorMessage = "El precio es obligatorio")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public decimal Precio { get; set; }
        #endregion


    }
}
