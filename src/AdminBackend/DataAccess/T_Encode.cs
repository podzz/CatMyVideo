//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminBackend.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Encode
    {
        public int id { get; set; }
        public int video { get; set; }
        public bool is_base { get; set; }
        public bool is_encoded { get; set; }
        public string input_format { get; set; }
        public int quality { get; set; }
    
        public virtual T_Videos T_Videos { get; set; }
    }
}
