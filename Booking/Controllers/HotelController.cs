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
         Booking_HotelsEntities db = new Booking_HotelsEntities();
        public ActionResult Index()
        {
            
            ViewBag.ResultType = "FirstActionResult";
            ViewBag.Intro = "Tận hưởng chuyến đi với kỳ lưu trú dài ngày ở khách sạn hoặc căn hộ";
            ViewBag.image = new mapImage().GetImage();
            var data = db.rooms.Where(r => r.status == "Còn Trống" && r.approve == "Đã Duyệt").ToList();
            return View(data);
        }
        // GET: Hotel
        [HttpGet]
        public ActionResult IndexByCityName(String cityName, int? IdPrice)
        {
            mapRoom dsrooms = new mapRoom();
            ViewBag.CountRoom = dsrooms.CountRoom(cityName);
            ViewBag.CityName = cityName;
            ViewBag.ResultTypeSecond = "Flag";
            
            return View("~/Views/Hotel/Index.cshtml",dsrooms.dsRoom(cityName,IdPrice));
        }
        [HttpGet]
        public ActionResult IndexByHotelType(int IDHotelType)
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            mapRoom dsrooms = new mapRoom();
            ViewBag.ResultTypeLast = "CountRoomWithHotelType";
            ViewBag.CountRoomWithHotelType = dsrooms.CountRoomWithHotelType(IDHotelType);
            var hotelType = db.hotel_type.FirstOrDefault(r => r.id == IDHotelType);
            ViewBag.HotelType = hotelType.hotel_type1;
           
            return View("~/Views/Hotel/Index.cshtml",dsrooms.dsRoom(IDHotelType));
        }
        [HttpGet]
        public ActionResult RoomDetail(int roomId)
        {
            mapRoomDetail getRoomDetail = new mapRoomDetail();
            List<roomDetail> getRoomImageDetail = getRoomDetail.GetRoomImageDetail(roomId);
            List<convenient> getRoomConvenient = getRoomDetail.GetRoomConvenientDetail(roomId);
            ViewBag.List_Image = getRoomImageDetail.Take(5);
            ViewBag.List_Convenient = getRoomConvenient;
            return View(getRoomDetail.GetRoomDetails(roomId));
        }
        public ActionResult Checkin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveCheckin()
        {
            return RedirectToAction("Index","Hotel");
        }
    }
}