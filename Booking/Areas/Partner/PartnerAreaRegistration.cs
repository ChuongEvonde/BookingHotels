﻿using System.Web.Mvc;

namespace Booking.Areas.Partner
{
    public class PartnerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Partner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Partner_default",
                "Partner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Booking.Areas.Partner.Controllers" }
            );
        }
    }
}