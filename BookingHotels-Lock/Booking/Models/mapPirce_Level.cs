using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Models
{
    public class mapPirce_Level

    {
        public List<price_level> dsPrice()
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            return (db.price_level.ToList());
        }
        
    }
}