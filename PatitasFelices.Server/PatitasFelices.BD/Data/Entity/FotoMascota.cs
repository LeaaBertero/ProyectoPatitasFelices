using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    [Index(nameof(FotoMascotaId), Name = "FotoMascotaId_UQ", IsUnique = true)]
    [Index(nameof(UrlFoto), nameof(Descripcion),
    Name = "UrlFoto_Descripcion", IsUnique = false)]
    public class FotoMascota : EntityBase
    {
        #region clave primaria
        public int FotoMascotaId { get; set; }
        #endregion

        #region clave foranea
        public int MascotaId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "La foto de la mascota es obligatoria")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string UrlFoto { get; set; }

        [Required(ErrorMessage = "El Nombre de usuario es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; }
        #endregion


    }
}
