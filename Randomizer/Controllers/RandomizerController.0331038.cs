using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Randomizer.Classes;
using static Randomizer.Classes.Randomizer;

namespace Randomizer.Controllers
{
    public partial class RandomizerController
    {
        #region Private Fields
        private List<string> names = new();
        //private List<SelectListItem> countries = new();
        #endregion

        #region RandomFirstNames
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

            try
            {
                using (var response =
                           await httpClient.GetAsync(
                               $"https://projectrandomizerteambril.azurewebsites.net/random_firstnames/{boy}/{girl}/{amountOfNames}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var answer = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                    ViewBag.Boy = boy;
                    ViewBag.Girl = girl;
                    ViewBag.AmountOfNames = amountOfNames;
                    ViewBag.Response = answer;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return View("RandomFirstNames");
        }
        #endregion

        #region RandomNames
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

        /// <summary>Gets random names and returns them to the view.</summary>
        /// <param name="country">The country.</param>
        /// <param name="amountOfNames">The amount of names.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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

        /// <summary>Gets random names from database.</summary>
        /// <param name="names">The names.</param>
        /// <param name="country">The country.</param>
        /// <param name="amountOfNames">The amount of names.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentException">No country was selected.
        /// or
        /// The given country is not supported, please use country codes like SP, IT, GE, etc.</exception>
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
                        $"https://projectrandomizerteambril.azurewebsites.net/random_names/{country}/{amountOfNames}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                names = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                ViewBag.AmountOfNames = amountOfNames;
                ViewBag.Names = names;
            }
            return names;
        }
        #endregion

        #region GetRandomSeason
        /// <summary>Returns the RandomSeason view</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IActionResult RandomSeason()
        {
            return View();
        }

        /// <summary>Gets a random season.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetRandomSeason()
        {
            try
            {
                using var httpClient = new HttpClient();
                using var response =
                await httpClient.GetAsync(
                        $"https://projectrandomizerteambril.azurewebsites.net/random_season/");
                string apiResponse = await response.Content.ReadAsStringAsync();
                var season = JsonConvert.DeserializeObject<Seasons>(apiResponse);
                ViewBag.Season = season;
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }
            return View("RandomSeason");
        }
        #endregion

        #region RandomTime

        /// <summary>Returns a plain RandomTime view</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IActionResult RandomTime()
        {
            return View();
        }
        /// <summary>Gets a random time and sends it to the RandomTime view.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<IActionResult> GetRandomTime()
        {
            try
            {
                using var httpClient = new HttpClient();
                using var response =
                await httpClient.GetAsync(
                        $"https://projectrandomizerteambril.azurewebsites.net/random_time/");
                string apiResponse = await response.Content.ReadAsStringAsync();
                var time = JsonConvert.DeserializeObject<Time>(apiResponse);
                ViewBag.Time = time;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return View("RandomTime");
        }
        #endregion
    }
}
