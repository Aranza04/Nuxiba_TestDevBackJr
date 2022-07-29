using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba_T2.Models
{
    [Keyless]
    public partial class ConsultaUsuario
    {
        [StringLength(100)]
        public string Login { get; set; } = null!;
        [StringLength(100)]
        public string Nombre { get; set; } = null!;
        [StringLength(100)]
        public string Paterno { get; set; } = null!;
        [StringLength(100)]
        public string Materno { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sueldo { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }
    }
}
