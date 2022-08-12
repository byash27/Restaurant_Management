using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Web.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class RestroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
