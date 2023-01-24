using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("EMPLEADOS")]
    public partial class EMPLEADO
    {
        public EMPLEADO()
        {
            SUELDOs = new HashSet<SUELDO>();
        }

        /// <summary>
        /// Identificador unico de usuario empleado
        /// </summary>
        [Key]
        [StringLength(225)]
        public string ASPNETUSER_ASPNETUSER_ID { get; set; }
        /// <summary>
        /// Identificador unico de turno
        /// </summary>
        public int TURNO_TurnoId { get; set; }

        [ForeignKey("ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("EMPLEADO")]
        public virtual ASPNETUSERS ASPNETUSER_ASPNETUSER { get; set; } = null!;
        [ForeignKey("TURNO_TurnoId")]
        [InverseProperty("EMPLEADOs")]
        public virtual TURNO TURNO_Turno { get; set; } = null!;
        [InverseProperty("EMPLEADOS_ASPNETUSER_ASPNETUSER")]
        public virtual ICollection<SUELDO> SUELDOs { get; set; }
    }
}
