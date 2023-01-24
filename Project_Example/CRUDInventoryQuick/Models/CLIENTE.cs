using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("CLIENTES")]
    public partial class CLIENTE
    {
        /// <summary>
        /// Identificador unico de usuario clientes
        /// </summary>
        [Key]
        [StringLength(225)]
        public string ASPNETUSER_ASPNETUSER_ID { get; set; }

        [ForeignKey("ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("CLIENTE")]
        public virtual ASPNETUSERS ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
