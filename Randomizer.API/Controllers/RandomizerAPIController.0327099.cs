namespace Randomizer.API.Controllers
{
    public partial class RandomizerAPIController
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
        [HttpGet("/date/{startDate}/{endDate?}")]
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


        /// <summary>Gets the random int.</summary>
        /// <param name="negative">if set to <c>true</c> [negative].</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("/int/{negative}")]
        public IResult getRandomInt(bool negative)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.GetRandomInt(negative));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }


        [HttpGet("/card/{includeJoker}")]
        public IResult getRandomCard(bool includeJoker)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.getImage(includeJoker));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        [HttpGet("/password/{length}")]
        public IResult getPasswordLength(int length)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.generatePassword(length));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        [HttpGet("/password/{length}/{lower}/{upper}/{special}/{number}")]
        public IResult getPasswordLengthParameters(int length, bool lower, bool upper, bool special, bool number)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.generatePassword(length, lower, upper, special, number));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        [HttpGet("/password/{lower}/{upper}/{special}/{number}")]
        public IResult getPasswordAmount(int lower, int upper, int special, int number)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.generatePassword(lower, upper, special, number));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
    }
}
