using Microsoft.AspNetCore.Mvc;

namespace Randomizer.API.Controllers
{
    public partial class RandomizerAPIController : ControllerBase
    {
        /// <summary>Defaults the random dice.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("random_dice")]
        public IResult defaultRandomDice()
        {
           return Results.Ok(Classes.Randomizer.RandomDice(1));
        }

        /// <summary>Randoms the dice with parameters.</summary>
        /// <param name="amount">The amount.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost("random_dice")]
        public IResult randomDiceWithParameters(int amount)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.RandomDice(amount));
            } catch (Exception e)
            {
               return Results.Problem(e.Message);
            }
        }

        /// <summary>Defaults the text.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("random_text")]
        public IResult defaultText()
        {
            return Results.Ok(Classes.Randomizer.GenerateRandomText(1, true, false));
        }


    }
}
