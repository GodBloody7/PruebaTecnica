using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAUS.EntidadesDeNegocio
{
    public class Planta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "El Id de Categoria es requerido")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [MaxLength(100, ErrorMessage ="El largo máximo es de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage="La descripcion es requerida")]
        [MaxLength(int.MaxValue, ErrorMessage ="El largo de caracteres es de máxima")]
        public string  Descripcion { get; set; }

        [Required(ErrorMessage ="La imagen es requerido")]
        public string ImagenUrl { get; set; }

        public Categoria Categoria { get; set; }

        [NotMapped]
        public int top_aux { get; set; }
    }



}
