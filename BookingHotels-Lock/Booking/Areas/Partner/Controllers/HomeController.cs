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
            ViewBag.Convenients = db.convenients.ToList();
            ViewBag.City = db.cities.ToList();
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddRoom( FormCollection f,List<String> convenients, List<HttpPostedFileBase> upload_image)
        {

            Booking_HotelsEntities db = new Booking_HotelsEntities();
           

           
            room rooms = new room {
                hotel_name = f["hotelType"],
                room_name = f["roomName"],
                hotel_type_id = int.Parse(f["hotelType"]),
                city_id = int.Parse(f["city"]),
                address = f["address"],
                des_address = f["des_address"],
                room_type = f["roomType"],
                des_room = f["desRoom"].Replace("<p>", "").Replace("</p>", "\n"),
                price_level_id = int.Parse(f["price_level"]),
                price = int.Parse(f["price"]), 
            };
            db.rooms.Add(rooms);
            db.SaveChanges();
            if (upload_image != null && upload_image.Count > 0)
            {
                foreach (var image in upload_image)
                {
                    if (image != null && image.ContentLength > 0)
                    {
                        // Tạo tên tệp duy nhất bằng cách thêm một số ngẫu nhiên vào tên tệp
                        string fileName = Path.GetFileName(image.FileName);
                        string imageName = Path.GetFileNameWithoutExtension(fileName);
                        string imageExtension = Path.GetExtension(fileName);
                        string uniqueFileName = $"{imageName}_{Guid.NewGuid()}{imageExtension}";

                        string imagePath = Path.Combine(Server.MapPath("~/Content/Images"), uniqueFileName);
                        if (!System.IO.File.Exists(imagePath))
                        {
                            image.SaveAs(imagePath);
                        }
                        roomDetail RoomDetail = new roomDetail {
                            room_id = rooms.id,
                            image = imagePath
                        };
                        db.roomDetails.Add(RoomDetail);
                    }
                }
                db.SaveChanges();
            }
            if (convenients != null && convenients.Count > 0)
            {
                foreach(var convi in convenients)
                {
                    
                    string icon = Request.Form["convenient_" + convi + "_icon"];
                    string convenient_name = Request.Form["convenient_" + convi];
                    int latestRoomId = db.rooms.OrderByDescending(r => r.id).Select(r => r.id).FirstOrDefault();
                    convenient convis = new convenient {
                        room_id = latestRoomId,
                        icon = icon,
                        convenient_name = convenient_name,

                    };
                    db.convenients.Add(convis);
                }
                db.SaveChanges();
            }

            //string encodedDesRoom = HttpUtility.HtmlEncode(f["desRoom"]);

            return RedirectToAction("Index");
        }

       
    }

}