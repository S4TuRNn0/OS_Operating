using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ASPNETUSERS")]
    public partial class ASPNETUSERS
    {
        public ASPNETUSERS()
        {
            ASPNETUSERCLAIMs = new HashSet<ASPNETUSERCLAIMS>();
            ASPNETUSERLOGINs = new HashSet<ASPNETUSERLOGIN>();
            ASPNETUSERROLEs = new HashSet<ASPNETUSERROLES>();
        }

        /// <summary>
        /// Identificador unico de usuario
        /// </summary>
        [Key]
        [StringLength(225)]
        public string Id { get; set; }
        /// <summary>
        /// Indica el nombre del usuario
        /// </summary>
        [StringLength(225)]
        public string NormalizedUserName { get; set; }
        /// <summary>
        /// Indica nombre de la persona
        /// </summary>
        [StringLength(225)]
        public string UserName { get; set; } = null!;
        /// <summary>
        /// Indica apellidos de la persona
        /// </summary>
        [StringLength(100)]
        public string? PhoneNumber { get; set; } = null!;
        /// <summary>
        /// Indica fecha de nacimiento de usuario
        /// </summary>
        [StringLength(100)]
        public string Email { get; set; } = null!;
        /// <summary>
        /// Indica telefono de usuario
        /// </summary>
        public bool EmailConfirmed { get; set; } 
        /// <summary>
        /// Indica el correo del usuario
        /// </summary>
        [StringLength(225)]
        public string NormalizedEmail { get; set; } = null!;
        /// <summary>
        /// Indica si el correo ha sido confirmado
        /// </summary>
        [StringLength(100)]
        public string PasswordHash { get; set; }
        /// <summary>
        /// Indica la contraseña de usuario
        /// </summary>
        [StringLength(225)]
        public string ConcurrencyStamp { get; set; } = null!;
        /// <summary>
        /// Indica el sello de seguridad del usuario
        /// </summary>
        [StringLength(225)]
        public string SecurityStamp { get; set; } = null!;
        /// <summary>
        /// Indica el reclamo de telefono usuario
        /// </summary>
        public int AccessFailedCount { get; set; }
        /// <summary>
        /// Indica factores disponibles
        /// </summary>
        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// Indica fecha cierre usuario
        /// </summary>
        [StringLength(225)]
        public string? LockoutEnd { get; set; } = null!;
        /// <summary>
        /// Indica fecha abierta usuario
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// Indica si el aceeso ha sido denegado
        /// </summary>
        public bool TwoFactorEnabled { get; set; } 

        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual ADMINISTRADOR ADMINISTRADOR { get; set; } = null!;
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual CAJERO CAJERO { get; set; } = null!;
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual CLIENTE CLIENTE { get; set; } = null!;
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual EMPLEADO EMPLEADO { get; set; } = null!;
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual ICollection<ASPNETUSERCLAIMS> ASPNETUSERCLAIMs { get; set; }
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual ICollection<ASPNETUSERLOGIN> ASPNETUSERLOGINs { get; set; }
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual ICollection<ASPNETUSERROLES> ASPNETUSERROLEs { get; set; }
    }
}
