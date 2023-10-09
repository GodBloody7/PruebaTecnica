using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAUS.EntidadesDeNegocio
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage ="El Id Rol es requerido")]
        [Display(Name ="Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage= "El nombre es requerido")]
        [MaxLength(75, ErrorMessage="El largo máximo es de 75 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage="El apellido es requerido")]
        [MaxLength(75, ErrorMessage ="El largo máximo es de 75 caracteres")]
        public string  Apellido { get; set; }
        [Required(ErrorMessage ="El Login es requerido")]
        [MaxLength (30, ErrorMessage= "El largo es máximo es de 30 caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]


        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password debe estar entre 6 a 50 caracteres", MinimumLength = 6)]

        public string Password { get; set; }

        [Required(ErrorMessage = "El estatus es requerido")]
        public byte Estatus { get; set; }

        [Display(Name = "Fecha registro")]
        public DateTime FechaRegistro { get; set; }

      

        public Rol Rol { get; set; }

        [NotMapped]
        public int top_aux { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password la contrasena")]
        [StringLength(50, ErrorMessage = "Password debe estar entre 6 a 50 caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y confirmar Password deben de ser iguales")]
        [Display(Name = "Confirmar contrasena")]
        public string confirmPassword_aux { get; set; }


        public enum EnumRol
        {
            Administrador = 1,
            Cliente = 2,
        }

    }
  

    public enum Estatus_Usuario
    {
        ACTIVO = 1, 
        INACTIVO = 2
    }
}
