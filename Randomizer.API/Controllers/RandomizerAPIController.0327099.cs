using Microsoft.AspNetCore.Mvc;

namespace Randomizer.API.Controllers
{
    public partial class RandomizerAPIController : ControllerBase
    {
        /// <summary>returns date, uses default settings</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("/date")]
        public IResult dateDefault()
        {
            return Results.Ok(Classes.Randomizer.GetRandomDate().ToShortDateString());
        }

        /// <summary>Date the with parameters.</summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost("/date")]
        public IResult dateWithParameters(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.GetRandomDate(startDate, endDate).ToShortDateString());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
    }
}
