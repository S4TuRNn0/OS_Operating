using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ASPNETUSERLOGIN")]
    public partial class ASPNETUSERLOGIN
    {
        /// <summary>
        /// Identificador unico de ingresar
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Indica ingreso
        /// </summary>
        [StringLength(64)]
        public string LoginProvider { get; set; } = null!;
        /// <summary>
        /// Indica llave
        /// </summary>
        [StringLength(64)]
        public string ProviderKey { get; set; } = null!;
        /// <summary>
        /// Identificador unico de usuario
        /// </summary>
        [StringLength(225)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("ASPNETUSERLOGINs")]
        public virtual ASPNETUSERS ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
