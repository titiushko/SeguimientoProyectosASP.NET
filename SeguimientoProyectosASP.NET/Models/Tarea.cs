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
    
    public partial class Tarea
    {
        public Tarea()
        {
            this.Responsable = new HashSet<Responsable>();
        }
    
        public decimal codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<decimal> codigo_proyecto { get; set; }
    
        public virtual Proyecto Proyecto { get; set; }
        public virtual ICollection<Responsable> Responsable { get; set; }
    }
}