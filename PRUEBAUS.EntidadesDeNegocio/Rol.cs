using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAUS.EntidadesDeNegocio
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage= "El nombre esa requerido")]
       [MaxLength(40, ErrorMessage ="El largo máximo es de 40 caracteres")]
        public string Nombre { get; set; }

        public List<Usuario> Usuarios { get; set; }

        [NotMapped]
        public int top_aux { get; set; }
    }
}
