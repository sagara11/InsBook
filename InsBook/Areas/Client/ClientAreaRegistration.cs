using System.Web.Mvc;

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
                "Client/{controller}/{action}/{friend_id}",
                new {controller="Login", action = "Index", friend_id = UrlParameter.Optional }
            );
        }
    }
}