using Microsoft.AspNetCore.Mvc;

namespace Randomizer.Controllers
{
    public partial class RandomizerController
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

        [HttpGet]
        public IActionResult randomImage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult randomPassword()
        {
            return View();
        }
    }
}
