using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerApiBasica.Models
{
    public partial class Empleados
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column("RFC")]
        [StringLength(13)]
        public string Rfc { get; set; }
        [StringLength(100)]
        public string Correo { get; set; }
    }
}
