using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Diagnostics;
using System.IO;

namespace Booking.Areas.Partner.Controllers
{
    public class HomeController : Controller
    {
        // GET: Partner/CreateRoom
        public ActionResult Index()
        {
            
            return View();
        }

      
        public ActionResult AddRoom()
        {
            Booking_HotelsEntities db = new Booking_HotelsEntities();
            ViewBag.Convenients = db.convenients.Take(7).ToList();
            ViewBag.City = db.cities.ToList();
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddRoom( FormCollection f, List<string> convenient, List<HttpPostedFileBase> upload_image)
        {

            Booking_HotelsEntities db = new Booking_HotelsEntities();

            string name = Path.GetFileName(upload_image.First().FileName);

            room Rooms = new room {
                hotel_name = f["hotelName"],
                room_name = f["roomName"],
                avatar_hotel = name,
                hotel_type_id = int.Parse(f["hotelType"]),
                city_id = int.Parse(f["city"]),
                address = f["address"],
                des_address = f["des_address"],
                room_type = f["roomType"],
                des_room = f["desRoom"].Replace("<p>", "").Replace("</p>", "\n"),
                price_level_id = int.Parse(f["price_level"]),
                price = int.Parse(f["price"]), 
                status = "Chưa Duyệt"
            };
            db.rooms.Add(Rooms);
            db.SaveChanges();
            if (upload_image != null && upload_image.Count > 0)
            {
                foreach (var image in upload_image)
                {
                    if (image != null && image.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(image.FileName);
                        string imagePath = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                        if (!System.IO.File.Exists(imagePath))
                        {
                            image.SaveAs(imagePath);
                        }
                        roomDetail RoomDetail = new roomDetail {
                            room_id = Rooms.id,
                            image = fileName
                        };
                        db.roomDetails.Add(RoomDetail);
                    }
                }
                db.SaveChanges(); // Move this line outside the foreach loop
            }
            foreach (var itemID in convenient)
            {
                var ID = int.Parse(itemID);
                var Data = db.convenients.FirstOrDefault(c => c.id == ID);

                // Thực hiện các thao tác lưu vào cơ sở dữ liệu ở đây
             
                convenient newItem = new convenient  {
                    room_id = Rooms.id,
                    icon = Data.icon,
                    convenient_name = Data.convenient_name,
                };

                db.convenients.Add(newItem);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();



            return RedirectToAction("Index");
        }

        
       
    }

}