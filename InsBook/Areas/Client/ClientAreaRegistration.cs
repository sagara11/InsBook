﻿using System.Web.Mvc;

namespace InsBook.Areas.Client
{
    public class ClientAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Client";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Client_default",
                "Client/{controller}/{action}/{id}",
                new {controller="Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}