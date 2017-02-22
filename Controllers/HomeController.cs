using Microsoft.AspNetCore.Mvc;

namespace CoreWebTest.Controllers
{
    [Route("[controller]"), Route("/")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index() {

            return View();
        }
    }
}