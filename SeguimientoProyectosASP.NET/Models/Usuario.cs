//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeguimientoProyectosASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Proyecto = new HashSet<Proyecto>();
            this.Responsable = new HashSet<Responsable>();
        }
    
        public string codigo { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string password { get; set; }
    
        public virtual ICollection<Proyecto> Proyecto { get; set; }
        public virtual ICollection<Responsable> Responsable { get; set; }
    }
}
