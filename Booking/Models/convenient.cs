//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Booking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class convenient
    {
        public int id { get; set; }
        public Nullable<int> room_id { get; set; }
        public string icon { get; set; }
        public string convenient_name { get; set; }
    
        public virtual room room { get; set; }
    }
}
