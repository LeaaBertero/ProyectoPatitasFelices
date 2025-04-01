using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(TarjetaId), Name = "TarjetaId_UQ", IsUnique = true)]
    [Index(nameof(FechaVencimiento), nameof(CodigoSeguridad),
    Name = "Fecha_CodigoSeguridad", IsUnique = false)]
    public class Tarjeta : EntityBase
    {
        #region clave primaria
        public int TarjetaId { get; set; }
        #endregion

        #region clave foranea
        public int UsuarioId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "El número de la tarjeta es obligatorio")]
        [MaxLength(16, ErrorMessage = "Máximo número de caracteres {1}")]
        public string NroTarjeta { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public DateOnly FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El código de seguridad es obligatorio")]
        [MaxLength(4, ErrorMessage = "Máximo número de caracteres {1}")]
        public string CodigoSeguridad { get; set; }
        #endregion
    }
}
