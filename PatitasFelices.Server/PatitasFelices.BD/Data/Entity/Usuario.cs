using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data.Entity
{
    public class Usuario : EntityBase
    {
        #region clave primaria
        public int UsuarioId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "El Nombre de usuario es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string CorreoElectronico_Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MaxLength(12, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Contrasenia { get; set; }

        //[Required(ErrorMessage = "El Nombre de usuario es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string FotoPerfil { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        //[MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public DateOnly FechaRegistro { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Rol { get; set; }
        #endregion
    }
}



