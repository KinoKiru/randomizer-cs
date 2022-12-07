using Microsoft.AspNetCore.Mvc;

namespace Randomizer.Controllers
{
    public partial class RandomizerController : Controller
    {
        [HttpGet]
        public IActionResult randomDate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult randomInt()
        {
            return View();
        }
    }
}
