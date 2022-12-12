using Microsoft.AspNetCore.Mvc;

namespace Randomizer.API.Controllers
{
    public partial class RandomizerAPIController
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
        [HttpGet("random_dice/{amount}")]
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

        /// <summary>Randoms the text with parameters.</summary>
        /// <param name="amount">The amount.</param>
        /// <param name="useEn">if set to <c>true</c> [use en].</param>
        /// <param name="useHtml">if set to <c>true</c> [use HTML].</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("random_text/{amount}/{useEn?}/{useHtml?}")]
        public IResult randomTextWithParameters(byte amount, bool useEn, bool useHtml)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.GenerateRandomText(amount, useEn, useHtml));
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        /// <summary>Randoms the color.</summary>
        /// <param name="knowColor">if set to <c>true</c> [know color].</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("random_color/{knowColor}")]
        public IResult randomColor(bool knowColor)
        {
            try
            {
                return Results.Ok(Classes.Randomizer.RandomColor(knowColor));
            } catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        /// <summary>Randoms the location.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("random_location")]
        public IResult randomLocation()
        {
            try
            {
                return Results.Ok(Classes.Randomizer.GetRandomLocation());
            } catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
    }
}
