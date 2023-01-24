using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ASPNETUSERCLAIMS")]
    public partial class ASPNETUSERCLAIMS
    {
        /// <summary>
        /// Identificador unico de llave
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Indica el tipo de llave
        /// </summary>
        [StringLength(64)]
        public string ClaimType { get; set; } = null!;
        /// <summary>
        /// Indica el valor de la llave
        /// </summary>
        [StringLength(64)]
        public string ClaimValue { get; set; } = null!;
        /// <summary>
        /// Identificador unico del usuario
        /// </summary>
        public int AspnetuserId { get; set; }
        /// <summary>
        /// Identificador unico de usuario
        /// </summary>
        [StringLength(225)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("ASPNETUSERCLAIMs")]
        public virtual ASPNETUSERS ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
