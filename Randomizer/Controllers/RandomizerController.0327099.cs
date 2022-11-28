using Microsoft.AspNetCore.Mvc;

namespace Randomizer.Controllers
{
    public partial class RandomizerController : Controller
    {
        public IActionResult randomDate()
        {
            return View();
        }
    }
}
