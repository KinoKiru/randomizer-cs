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
        private List<SelectListItem> countries = new();
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
        public IActionResult RandomNames(string country)
        {
            try
            {
                GetNames(names, country, 0);
                ViewBag.Countries = countries;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomNames(string country, int amountOfNames)
        {
            if (country == null)
            {
                try
                {
                    GetNames(names, country, amountOfNames);
                    ViewBag.Countries = countries;
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            try
            {
                GetNames(names, country, amountOfNames);
                ViewBag.Names = names;
                ViewBag.Selected = country;
                ViewBag.Countries = countries;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("RandomNames");
        }

        public List<string> GetNames(List<string> names, string country, int amountOfNames)
        {
            bool valid = false;

            List<SelectListItem> countries = new List<SelectListItem>();
            countries.Add(new SelectListItem("Spanje", "SP"));
            countries.Add(new SelectListItem("Italië", "IT"));
            countries.Add(new SelectListItem("Griekenland", "GR"));
            countries.Add(new SelectListItem("Polen", "PL"));
            countries.Add(new SelectListItem("Duitsland", "GE"));
            this.countries = countries;

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
                throw new ArgumentException("This country does not exist in this list.");
            }

            if (country is not "" or null)
            {
                switch (country)
                {
                    case "SP":
                        for (int i = 0; i < amountOfNames; i++)
                        {
                            names.Add("Spaanse naam");
                        }
                        break;
                    case "IT":
                        for (int i = 0; i < amountOfNames; i++)
                        {
                            names.Add("Italiaanse naam");
                        }
                        break;
                    case "GR":
                        for (int i = 0; i < amountOfNames; i++)
                        {
                            names.Add("Griekse naam");
                        }
                        break;
                    case "PL":
                        for (int i = 0; i < amountOfNames; i++)
                        {
                            names.Add("Poolse naam");
                        }
                        break;
                    case "GE":
                        for (int i = 0; i < amountOfNames; i++)
                        {
                            names.Add("Duitse naam");
                        }
                        break;
                }
            }
            this.names = names;
            return names;
        }
    }
}
