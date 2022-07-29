using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba_T2.Models
{
    [Table("empleados")]
    public partial class Empleado
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sueldo { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }
        [Column("userId")]
        public int UserId { get; set; }
        [Key]
        [Column("empleadoId")]
        public int EmpleadoId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Empleados")]
        public virtual Usuario User { get; set; } = null!;
    }
}
