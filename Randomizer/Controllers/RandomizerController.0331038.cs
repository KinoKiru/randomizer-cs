using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Globalization;

namespace Randomizer.Controllers
{
    public partial class RandomizerController
    {
        #region Private Fields
        private List<string> names = new();
        //private List<SelectListItem> countries = new();
        #endregion
        /// <summary>Returns the default RandomFirstNames View</summary>
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

        /// <summary>Returns the default RandomNames View</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IActionResult> RandomNames(string country)
        {
            try
            {
                await GetRandomNames(names, country, 0);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomNames(string? country, int amountOfNames)
        {
            if (country == null || country.Length != 2)
            {
                try
                {
                    await GetRandomNames(names, country, amountOfNames);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            else
            {
                try
                {
                    await GetRandomNames(names, country, amountOfNames);
                    ViewBag.Selected = country;
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            return View("RandomNames");
        }

        public async Task<List<string>> GetRandomNames(List<string> names, string country, int amountOfNames)
        {
            List<SelectListItem> countries = new()
            {
                new("Spanje", "SP"),
                new("Italië", "IT"),
                new("Griekenland", "GR"),
                new("Polen", "PL"),
                new("Duitsland", "GE")
            };
            ViewBag.Countries = countries;

            if (country == "Selecteer een land")
            {
                ViewBag.AmountOfNames = amountOfNames;
                throw new ArgumentException("No country was selected.");
            }

            bool valid = false;
            foreach (SelectListItem value in countries)
            {
                if (value.Value == country)
                {
                    value.Selected = true;
                    valid = true;
                    break;
                }
            }

            if (!valid && country != null)
            {
                throw new ArgumentException("The given country is not supported, please use country codes like SP, IT, GE, etc.");
            }

            if (country != null)
            {
                using var httpClient = new HttpClient();
                using var response =
                    await httpClient.GetAsync(
                        $"https://localhost:7298/random_names/{country}/{amountOfNames}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                names = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                ViewBag.AmountOfNames = amountOfNames;
                ViewBag.Names = names;
            }
            return names;
        }
    }
}
