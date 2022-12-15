using Microsoft.AspNetCore.Mvc;
using Randomizer.Classes;
using static Randomizer.Classes.Randomizer;

namespace Randomizer.API.Controllers
{
    public partial class RandomizerAPIController
    {
        #region RandomFirstNames
        /// <summary>Returns a default API Call result</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        [Route("random_firstnames")]
        public List<string> DefaultRandomFirstNames()
        {
            return GetRandomFirstNames(true, true, 1);
        }
        /// <summary>Returns a string of arrays containing a given amount of random first names of boys and/of girls depending on the users choices.</summary>
        /// <param name="boy">if set to <c>true</c> [boy].</param>
        /// <param name="girl">if set to <c>true</c> [girl].</param>
        /// <param name="amountOfNames">The amount of names.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        [Route("random_firstnames/{boy:bool}/{girl:bool}/{amountOfNames:int}")]
        public string[] RandomFirstNames(bool boy, bool girl, int amountOfNames)
        {
            try
            {
                return GetRandomFirstNames(boy, girl, amountOfNames).ToArray();
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
        #endregion

        #region RandomNames
        /// <summary>Tests a default Random Name result.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        [Route("random_names")]
        public IResult DefaultNames()
        {
            return Results.Ok(GetRandomNames("SP", 1));
        }

        /// <summary>returns Random Names</summary>
        /// <param name="country">The country.</param>
        /// <param name="amountOfNames">The amount of names.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        [Route("random_names/{country}/{amountOfNames:int}")]
        public string[] RandomNames(string country, int amountOfNames)
        {
            try
            {
                return GetRandomNames(country, amountOfNames).ToArray();
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
        #endregion

        #region RandomSeason

        /// <summary>Returns a random season</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        [Route("random_season")]
        public Seasons RandomSeason()
        {
            return GetRandomSeason();
        }
        #endregion

        #region RandomTime
        /// <summary>Gets a random time from a amount of seconds.</summary>
        /// <param name="seconds">The seconds.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        [Route("random_time")]
        public Time RandomTime()
        {
            return GetRandomTime();
        }
        #endregion
    }
}
