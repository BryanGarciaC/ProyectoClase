//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoClase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pago
    {
        public int Idpago { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public int valor { get; set; }
        public int idfactura { get; set; }
    
        public virtual Registro Registro { get; set; }
    }
}
