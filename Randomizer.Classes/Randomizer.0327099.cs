namespace Randomizer.Classes
{
    public static partial class Randomizer
    {


        /// <summary>Gets the random date.</summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>returns random value, if start date if given generates random date bewteen now and given date and if endate is given then generate date between start and given date</returns>
        public static DateOnly GetRandomDate(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                Random rng = new Random();
                DateTime tempDateTime = startDate == null ? new DateTime(1900, 1, 1) : (DateTime)startDate;
                int range = ((endDate == null ? DateTime.Today : (DateTime)endDate) - tempDateTime).Days;
                DateTime newDate = tempDateTime.AddDays(rng.Next(range));
                return new DateOnly(newDate.Year, newDate.Month, newDate.Day);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
