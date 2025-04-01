using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(ReservaId), Name = "ReservaId_UQ", IsUnique = true)]
    [Index(nameof(FechaHoraInicio), nameof(FechaHoraFin), nameof(EstadoReserva),
    Name = "FechaHoraInicio_FechaHoraFin_EstadoReserva", IsUnique = false)]
    public class Reserva : EntityBase
    {
        #region clave primaria
        public int ReservaId { get; set; }
        #endregion

        #region claves foraneas
        public int UsuarioId { get; set; }
        public int ServicioId { get; set; }
        public int MascotaId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "La fecha de inicio de la reserva es obligatoria")]
        public DateTime FechaHoraInicio { get; set; }

        [Required(ErrorMessage = "La fecha de finalización de la reserva es obligatoria")]
        public DateTime FechaHoraFin { get; set; }

        [Required(ErrorMessage = "El estado de la reserva es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}")]
        public string EstadoReserva { get; set; }
        #endregion
    }
}
