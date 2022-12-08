using Microsoft.AspNetCore.Mvc;

namespace Randomizer.API.Controllers
{
    public partial class RandomizerAPIController
    {
        [HttpGet]
        [Route("random_firstnames")]
        public IResult defaultRandomFirstNames()
        {
            return Results.Ok(Classes.Randomizer.GetRandomFirstNames(true, true, 1));
        }
        [HttpGet]
        [Route("random_firstnames/{boy:bool}/{girl:bool}/{amountOfNames:int}")]
        public string[] RandomFirstNames(bool boy, bool girl, int amountOfNames)
        {
            try
            {
                return Classes.Randomizer.GetRandomFirstNames(boy, girl, amountOfNames).ToArray();
            }
            catch (Exception e)
            {
                return new string[] {e.Message};
            }
        }
    }
}
