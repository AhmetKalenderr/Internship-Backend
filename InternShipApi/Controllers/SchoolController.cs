using Microsoft.AspNetCore.Mvc;

namespace InternShipApi.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
