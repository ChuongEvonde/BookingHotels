using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Models
{
    public class mapHotel_type
    {
        public List<hotel_type> dsHotel_Type()
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            return (db.hotel_type.ToList());
        }
    }
}