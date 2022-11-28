using Microsoft.AspNetCore.Mvc;

namespace Randomizer.API.Controllers
{
    public partial class RandomizerAPIController : ControllerBase
    {
        [HttpGet("/date")]
        public ActionResult<DateOnly> Index()
        {
            return Classes.Randomizer.GetRandomDate();
        }

        [HttpGet("/date/{startdate?}")]
        public ActionResult<DateOnly> Index(DateOnly? startdate)
        {
            try
            {
                return Classes.Randomizer.GetRandomDate(((DateOnly)startdate).ToDateTime(TimeOnly.Parse("10:00 PM")));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
