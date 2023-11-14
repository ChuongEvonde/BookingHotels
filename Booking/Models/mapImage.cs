using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Models
{
    public class mapImage
    {
        public string GetImage()
        {
            using (Booking_HotelsEntities db = new Booking_HotelsEntities())
            {
                var image = (from roomDetail in db.roomDetails
                             join room in db.rooms on roomDetail.room_id equals room.id
                            
                             select roomDetail.image).FirstOrDefault();

                if (image != null)
                {
                
                    string imageString = Convert.ToString(image);

                    return imageString;
                }
            }

            return null;
        }
    }   
}