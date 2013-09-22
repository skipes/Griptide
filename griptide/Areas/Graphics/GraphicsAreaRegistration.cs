using System.Web.Mvc;

namespace griptide.Areas.Graphics
{
    public class GraphicsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Graphics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Graphics_default",
                "Graphics/{controller}/{action}/{id}",
                new { controller="Graphics", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
