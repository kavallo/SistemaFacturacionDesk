//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaFacturacionDesk
{
    using System;
    using System.Collections.Generic;
    
    public partial class VENDEDORES
    {
        public VENDEDORES()
        {
            this.FACTURAS = new HashSet<FACTURAS>();
        }
    
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public int porcientoComision { get; set; }
        public string nombreUsuario { get; set; }
        public string estado { get; set; }
        public string contrasena { get; set; }
        public bool IsAdmin { get; set; }
    
        public virtual ICollection<FACTURAS> FACTURAS { get; set; }
    }
}
