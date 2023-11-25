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
    
    public partial class room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public room()
        {
            this.convenients = new HashSet<convenient>();
            this.roomDetails = new HashSet<roomDetail>();
        }
    
        public int id { get; set; }
        public string hotel_name { get; set; }
        public string room_name { get; set; }
        public string avatar_hotel { get; set; }
        public Nullable<int> price { get; set; }
        public string address { get; set; }
        public string room_type { get; set; }
        public string des_address { get; set; }
        public string des_room { get; set; }
        public Nullable<int> hotel_type_id { get; set; }
        public Nullable<int> city_id { get; set; }
        public Nullable<int> price_level_id { get; set; }
        public string status { get; set; }
        public string approve { get; set; }
    
        public virtual city city { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<convenient> convenients { get; set; }
        public virtual hotel_type hotel_type { get; set; }
        public virtual price_level price_level { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<roomDetail> roomDetails { get; set; }
    }
}
