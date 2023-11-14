using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booking.Models;

namespace Booking.Controllers
{
    public class HomeController : Controller
    {
        
        
        public ActionResult Index()
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            ViewBag.dsCity = db.cities.Take(5).ToList();
            ViewBag.dsHotelType = db.hotel_type.ToList();
            var dsCity = db.cities.ToList();
            return View(dsCity);
        }

      

       
    }
}