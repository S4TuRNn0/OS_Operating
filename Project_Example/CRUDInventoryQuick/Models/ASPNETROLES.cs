using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ASPNETROLES")]
    public partial class ASPNETROLES
    {
        public ASPNETROLES()
        {
            ASPNETUSERROLEs = new HashSet<ASPNETUSERROLES>();
        }

        /// <summary>
        /// Identificador unico de Rol
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Indica el nombre del rol correspondiente
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [InverseProperty("ASPNETROLES_ASPNETROLES")]
        public virtual ICollection<ASPNETUSERROLES> ASPNETUSERROLEs { get; set; }
    }
}
