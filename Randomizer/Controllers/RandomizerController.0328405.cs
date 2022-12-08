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
    }
}
