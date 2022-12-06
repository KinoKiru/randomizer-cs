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
                DateTime tempDateTime = startDate == null ? new DateTime(1900, 1, 1) : (DateTime)startDate;
                if ((endDate != null && startDate < endDate) || endDate == null)
                {
                    int range = ((endDate == null ? DateTime.Today : (DateTime)endDate) - tempDateTime).Days;
                    return tempDateTime.AddDays(rng.Next(range));
                }
                throw new ArgumentException("Einddatum mag niet kleiner zijn dan startdatum");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>Gets the random int.</summary>
        /// <param name="negative">if set to <c>true</c> [negative].</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int GetRandomInt(bool negative)
        {
            int owo = rng.Next((negative ? Int32.MinValue : 0), Int32.MaxValue);
            //TODO if only negative if (negative)
            //{
            //    while (owo > 0)
            //    {
            //        owo = rng.Next((negative ? Int32.MinValue : 0), Int32.MaxValue);
            //    }
            //}
            return owo;
        }
    }
}
