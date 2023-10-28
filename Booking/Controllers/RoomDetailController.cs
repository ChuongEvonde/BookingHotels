using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booking.Controllers
{
    public class RoomDetailController : Controller
    {
        // GET: RoomDetail
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
     
        public ActionResult Index(int roomId)
        {
            mapRoomDetail getRoomDetail = new mapRoomDetail();
            List<roomDetail> getRoomImageDetail = getRoomDetail.GetRoomImageDetail(roomId);
            List<convenient> getRoomConvenient = getRoomDetail.GetRoomConvenientDetail(roomId);
            ViewBag.List_Image = getRoomImageDetail;
            ViewBag.List_Convenient = getRoomConvenient;
            return View(getRoomDetail.GetRoomDetails(roomId));
        }
        public ActionResult BookingSuccess()
        {
            // Thực hiện các thao tác liên quan đến đặt phòng thành công ở đây
            return View();
        }





    }
}