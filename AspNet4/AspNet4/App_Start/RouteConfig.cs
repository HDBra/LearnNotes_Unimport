using System.Web.Routing;

namespace AspNet4.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "list/{category}/{page}", "~/pages/Listing.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
            //routes.MapPageRoute(null, "pages", "~/Pages/Listing.aspx");
            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");
        }
    }
}