using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ADMINISTRADOR")]
    public partial class ADMINISTRADOR
    {
        /// <summary>
        /// Identificador Unico de cada Usuario
        /// </summary>
        [Key]
        [StringLength(225)]
        public string ASPNETUSER_ASPNETUSER_ID { get; set; }

        [ForeignKey("ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("ADMINISTRADOR")]
        public virtual ASPNETUSERS ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
