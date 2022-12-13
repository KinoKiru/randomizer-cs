using Microsoft.AspNetCore.Mvc;

namespace Randomizer.Controllers
{
    public partial class RandomizerController : Controller
    {

        [HttpGet]
        public IActionResult randomDice()
        {
            return View();
        }
        [HttpGet]
        public IActionResult randomText()
        {
            return View();
        }
        [HttpGet]
        public IActionResult randomColor()
        {
            return View();
        }
        [HttpGet]
        public IActionResult randomLocation()
        {
            return View();
        }
    }
}
