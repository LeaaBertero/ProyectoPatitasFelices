using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(FotoId), Name = "FotoId_UQ", IsUnique = true)]
    [Index(nameof(UrlFoto), nameof(Descripcion),
    Name = "UrlFoto_Descripcion", IsUnique = false)]
    public class Foto : EntityBase
    {
        #region clave primaria
        public int FotoId { get; set; }
        #endregion

        #region claves foraneas
        public int MascotaId { get; set; }
        public int UsuarioId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "La foto de perfil es obligatoria")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string UrlFoto { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; }
        #endregion
    }
}
