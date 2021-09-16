using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthPrestamos.Models
{
    public class Prestamo
    {
        [Key]
        public int  Id { get; set; }

        [Required(ErrorMessage = "Cantidad es obligatorio")]
        [Display(Name = "Cantidad")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Cantidad { get; set; }

        [Required]
        public string IdUsuario { get; set; }


        public virtual List<Abono> Abonosssss { get; set; }

    }
}
