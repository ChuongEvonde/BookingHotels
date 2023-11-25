using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Models
{
    public class mapRoomDetail
    {
        public List<room> GetRoomDetails(int roomId)
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();

            var roomDetails = db.rooms.Where(r => r.id == roomId).ToList();

            return roomDetails;
        }
        public List<roomDetail> GetRoomImageDetail(int roomId)
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            var roomDetails = db.roomDetails.Where(r => r.room_id == roomId).ToList();
            return roomDetails;
        }
        public List<convenient> GetRoomConvenientDetail(int roomId)
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            var convenient = db.convenients.Where(r => r.room_id == roomId).ToList();
            return convenient;
        }
      
    }
}