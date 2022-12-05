namespace Randomizer.Classes
{
    public static partial class Randomizer
    {


        /// <summary>Gets the random date.</summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>returns random value, if start date if given generates random date bewteen now and given date and if endate is given then generate date between start and given date</returns>
        public static DateTime GetRandomDate(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                if (endDate != null && startDate == null)
                {
                    throw new ArgumentException("eind datum mag niet later dan de start datum zijn");
                }
                if (startDate < endDate)
                {
                    DateTime tempDateTime = startDate == null ? new DateTime(1900, 1, 1) : (DateTime)startDate;
                    int range = ((endDate == null ? DateTime.Today : (DateTime)endDate) - tempDateTime).Days;
                    return tempDateTime.AddDays(rng.Next(range));
                }
                else
                {
                    throw new ArgumentException("eind datum mag niet later dan de start datum zijn");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
