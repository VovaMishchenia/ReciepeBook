//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_access_layer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Friend
    {
        public int Id { get; set; }
        public Nullable<int> friend1 { get; set; }
        public Nullable<int> friend2 { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
