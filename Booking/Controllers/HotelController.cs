using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booking.Models;

namespace Booking.Controllers
{
    public class HotelController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ResultType = "FirstActionResult";
            ViewBag.Intro = "Tận hưởng chuyến đi với kỳ lưu trú dài ngày ở khách sạn hoặc căn hộ";
            return View(new Booking_HotelsEntities().rooms.ToList());
        }
        // GET: Hotel
        [HttpPost]
        public ActionResult Index(String cityName, int? IdPrice)
        {
            mapRoom dsrooms = new mapRoom();
            ViewBag.CountRoom = dsrooms.CountRoom(cityName);
            ViewBag.CityName = cityName;
            return View(dsrooms.dsRoom(cityName,IdPrice));
        }
       [HttpGet]
        public ActionResult RoomDetail(int roomId)
        {
            mapRoomDetail getRoomDetail = new mapRoomDetail();
            List<roomDetail> getRoomImageDetail = getRoomDetail.GetRoomImageDetail(roomId);
            List<convenient> getRoomConvenient = getRoomDetail.GetRoomConvenientDetail(roomId);
            ViewBag.List_Image = getRoomImageDetail;
            ViewBag.List_Convenient = getRoomConvenient;
            return View(getRoomDetail.GetRoomDetails(roomId));
        }
    }
}