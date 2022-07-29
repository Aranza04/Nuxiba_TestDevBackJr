using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba_T2.Models
{
    [Keyless]
    public partial class Consulta1
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sueldo { get; set; }
        [Column("userId")]
        public int UserId { get; set; }
    }
}
