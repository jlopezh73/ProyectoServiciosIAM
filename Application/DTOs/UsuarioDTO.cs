using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TorneoServiciosIAM.Application.DTOs
{
    public class UsuarioDTO
    {
        public String ID { get; set; }
        [Required(ErrorMessage = "El Correo electrónico es obligatorio", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        [Display(Name = "Correo electrónico", Prompt = "Correo de registro del usuario")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [DataType(DataType.EmailAddress)]
        public String CorreoElectronico { get; set; }

        public String nombreCompleto
        {
            get
            {
                return $"{Paterno} {Materno} {Nombre}";
            }
        }

        [Required(ErrorMessage = "El Apellido Paterno es obligatorio", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "El apellido paterno no puede exceder los 50 caracteres.")]
        [Display(Name = "Apellido paterno", Prompt = "Apellido paterno del usuario")]
        public string? Paterno { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es obligatorio", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "El apellido materno no puede exceder los 50 caracteres.")]
        [Display(Name = "Apellido materno", Prompt = "Apellido materno del usuario")]
        public string? Materno { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        [Display(Name = "Nombre", Prompt = "nombre del usuario")]
        public string? Nombre { get; set; }
        public string? Puesto { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "La contraseña no puede exceder los 50 caracteres.")]
        [Display(Name = "Contraseña", Prompt = "Contraseña del usuario")]
        public string? Password { get; set; }


        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        [Display(Name = "Validación de la Contraseña", Prompt = "Contraseña del usuario")]
        public string? PasswordValidacion { get; set; }

        public ulong? Activo { get; set; }

        public Boolean ActivoBoolean
        {
            get
            {
                return Activo == 1;
            }
            set
            {
                Activo = value ? (ulong)1 : (ulong)0;
            }
        }
    }
}