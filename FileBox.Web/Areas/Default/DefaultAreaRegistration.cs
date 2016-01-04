using System.Web.Mvc;

namespace FileBox.Web.Areas.Default
{
    public class DefaultAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Default";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"FileBox.Web.Areas.Default.Controllers"}
            );
        }
    }
}