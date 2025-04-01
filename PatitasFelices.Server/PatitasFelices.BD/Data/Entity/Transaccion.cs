using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(TransaccionId), Name = "TransaccionId_UQ", IsUnique = true)]
    [Index(nameof(Monto), nameof(MetodoPago),
    Name = "Monto_MetodoPago", IsUnique = false)]
    public class Transaccion : EntityBase
    {
        //clave primaria
        #region clave primaria
        public int TransaccionId { get; set; }
        #endregion
        
        //claves foraneas
        #region claves foraneas
        public int UsuarioId { get; set; }
        public int TarjetaId { get; set; }
        public int ReservaId { get; set; }
        public int ServicioId { get; set; }
        #endregion

        //atributos
        #region atributos
        [Required(ErrorMessage = "El monto es obligatorio")]
        //[MaxLength(12, ErrorMessage = "Máximo número de caracteres {1}")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}")]
        public string MetodoPago { get; set; }
        #endregion

    }
}
