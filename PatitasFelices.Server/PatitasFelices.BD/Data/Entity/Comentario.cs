using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(ComentarioId), Name = "ComentarioId_UQ", IsUnique = true)]
    [Index(nameof(TextoComentario), nameof(FechaPublicacion),
    Name = "TextoComentario_FechaPublicacion", IsUnique = false)]
    public class Comentario : EntityBase
    {
        #region clave primaria
        public int ComentarioId { get; set; }
        #endregion

        #region claves foraneas
        public int UsuarioAutoId { get; set; }
        public int UsuarioDestinatarioId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "El comentario es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string TextoComentario { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        //[MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public DateOnly FechaPublicacion { get; set; }
        #endregion
    }
}
