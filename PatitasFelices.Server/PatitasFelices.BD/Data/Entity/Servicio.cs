using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(ServicioId), Name = "ServicioId_UQ", IsUnique = true)]
    [Index(nameof(NombreServicio),
    Name = "NombreServicio", IsUnique = false)]
    public class Servicio : EntityBase
    {
        #region clave primaria
        public int ServicioId { get; set; }
        #endregion

        #region atributo
        [Required(ErrorMessage = "El Nombre del servicio es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string NombreServicio { get; set; }
        #endregion
    }
}
