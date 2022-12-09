using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Randomizer.Controllers
{
    public partial class RandomizerController
    {
        /// <summary>Randoms the default RandomFirstNames view</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IActionResult RandomFirstNames()
        {
            return View();
        }

        /// <summary>Gets the desired amount of random first names of boys and girls according to your choices.</summary>
        /// <param name="boy">if set to <c>true</c> [boy].</param>
        /// <param name="girl">if set to <c>true</c> [girl].</param>
        /// <param name="amountOfNames">The amount of names.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetRandomFirstNames(bool boy, bool girl, int amountOfNames)
        {
            using var httpClient = new HttpClient();
            if (boy == false && girl == false)
            {
                ViewBag.Error = "At least one of the boy/girl booleans must be true.";
                ViewBag.Boy = boy;
                ViewBag.Girl = girl;
                ViewBag.AmountOfNames = amountOfNames;
                return View("RandomFirstNames");
            }

            if (amountOfNames < 1)
            {
                ViewBag.Error = "The number of given names must be at least 1.";
                ViewBag.Boy = boy;
                ViewBag.Girl = girl;
                ViewBag.AmountOfNames = amountOfNames;
                return View("RandomFirstNames");
            }

            using (var response =
                   await httpClient.GetAsync(
                       $"https://localhost:7298/random_firstnames/{boy}/{girl}/{amountOfNames}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                ViewBag.Boy = boy;
                ViewBag.Girl = girl;
                ViewBag.AmountOfNames = amountOfNames;
                ViewBag.Response = answer;
            }

            return View("RandomFirstNames");
        }
    }
}
