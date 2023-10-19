using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Models
{
    public class mapRoom
    {
        public List<room> dsRoom(String cityName, int? Idprice)
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            var data = (from room in db.rooms
                        join city in db.cities on room.city_id equals city.id
                        join priceLevel in db.price_level on room.price_level_id equals priceLevel.id
                        where city.city_name == cityName && (priceLevel.id == Idprice || Idprice == null)
                        select room

             ).ToList();
            return data;
        }
        public List<room> rooms()
        {
            return (new Booking_HotelsEntities().rooms.ToList());
        }
        public int CountRoom(String cityName)
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            var name = db.cities.FirstOrDefault(r => r.city_name == cityName);
            int id = 0;
            if(name != null)
            {
                id = name.id;
            }
            var count = db.rooms.Count(r => r.city_id == id);
            return count;
        }
      
    } 
}