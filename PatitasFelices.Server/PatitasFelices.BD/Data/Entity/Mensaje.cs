using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(MensajeId), Name = "MensajeId_UQ", IsUnique = true)]
    [Index(nameof(ContenidoMensaje), nameof(FechaHoraMensaje),
    Name = "ContenidoMensaje_FechaHoraMensaje", IsUnique = false)]
    public class Mensaje : EntityBase
    {
        #region clave primaria
        public int MensajeId { get; set; }
        #endregion
        
        #region claves foraneas
        public int UsuarioEmisorId { get; set; }
        public int UsuarioReceptorId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "El contenido del mensaje es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string ContenidoMensaje { get; set; }

        [Required(ErrorMessage = "La fecha del mensaje es obligatoria")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public DateTime FechaHoraMensaje { get; set; }
        #endregion


    }
}
