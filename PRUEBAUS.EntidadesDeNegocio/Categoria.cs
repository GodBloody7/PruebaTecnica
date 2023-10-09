using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAUS.EntidadesDeNegocio
{
    public class Categoria
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [MaxLength(1000, ErrorMessage ="El largo máximo es de 1000 caracteres")]

        public string Nombre { get; set; }

        public List<Planta> Plantas { get; set; }


        [NotMapped]
        public int top_aux { get; set; }
    }
}
