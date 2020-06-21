//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReciepeBook.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reciepe
    {
        public int Id { get; set; }
        public string ReciepeName { get; set; }
        public string Ingredients { get; set; }
        public string PhotoPath { get; set; }
        public string Instruction { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> CuisineId { get; set; }
        public int CookingTime { get; set; }
        public Nullable<int> Rating { get; set; }
        public int Calories { get; set; }
    
        public virtual Cuisine Cuisine { get; set; }
        public virtual ReciepeType ReciepeType { get; set; }
    }
}
