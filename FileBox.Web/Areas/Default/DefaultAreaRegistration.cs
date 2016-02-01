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
                name: "ShortUrls",
                url: "_{name}",
                defaults: new { area = "Default", controller = "ShortUrl", action = "Index", name = UrlParameter.Optional }
             );
            context.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"FileBox.Web.Areas.Default.Controllers"}
            );
            context.MapRoute(
                name: "Default1",
                url: "{controller}/{action}/{fInfo}",
                defaults: new { controller = "Home", action = "Index", fInfo = UrlParameter.Optional },
                namespaces: new[] { "FileBox.Web.Areas.Default.Controllers" }
            );
        }
    }
}