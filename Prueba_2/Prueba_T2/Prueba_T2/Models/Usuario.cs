using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba_T2.Models
{
    [Table("usuarios")]
    public partial class Usuario
    {
        public Usuario()
        {
            Empleados = new HashSet<Empleado>();
        }

        [StringLength(100)]
        public string Login { get; set; } = null!;
        [StringLength(100)]
        public string Nombre { get; set; } = null!;
        [StringLength(100)]
        public string Paterno { get; set; } = null!;
        [StringLength(100)]
        public string Materno { get; set; } = null!;
        [Key]
        [Column("userId")]
        public int UserId { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
