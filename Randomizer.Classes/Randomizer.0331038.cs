using Microsoft.Data.SqlClient;
using System.Data;

namespace Randomizer.Classes
{
    public static partial class Randomizer
    {
        #region RandomFirstNames
        /// <summary>Gets a list of random first names of boys/girls depending on your prefrences.</summary>
        /// <param name="boy">if set to <c>true</c> [boy].</param>
        /// <param name="girl">if set to <c>true</c> [girl].</param>
        /// <param name="amountOfNames">The amount of names.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentException">Het aantal opgevraagde namen moet minstens 1 zijn.</exception>
        /// <exception cref="System.Exception"></exception>
        public static List<string> GetRandomFirstNames(bool boy, bool girl, int amountOfNames)
        {
            if (amountOfNames < 1)
            {
                throw new ArgumentException("The number of given names must be at least 1.");
            }

            if (!boy && !girl)
            {
                throw new ArgumentException("At least one of the boy/girl booleans must be true.");
            }

            try
            {
                List<string> allFirstNames = new();
                List<string> finalFirstNames = new();
                if (boy)
                {
                    allFirstNames.AddRange(File.ReadAllLines("Recources/Text/jongensvoornamen.txt").ToList());
                }

                if (girl)
                {
                    allFirstNames.AddRange(File.ReadAllLines("Recources/Text/meisjesvoornamen.txt").ToList());
                }

                for (int i = 0; i < amountOfNames; i++)
                {
                    finalFirstNames.Add(allFirstNames[rng.Next(0, allFirstNames.Count)].Replace("\t", ""));
                }

                return finalFirstNames;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region RandomNames
        /// <summary>Gets a list of random names.</summary>
        /// <param name="country">The country.</param>
        /// <param name="amountOfNames">The amount of names.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The number of given names must be at least 1.
        /// or
        /// The given country is not supported, please use country codes like SP, IT, GE, etc.
        /// or
        /// No country was selected.
        /// </exception>
        /// <exception cref="System.Exception"></exception>
        public static List<string> GetRandomNames(string country, int amountOfNames)
        {
            if (amountOfNames is < 1 or > 100)
            {
                throw new ArgumentException("The number of given names must be at least 1.");
            }

            if (string.IsNullOrEmpty(country) || country.Length != 2 && country != "Selecteer een land")
            {
                throw new ArgumentException("The given country is not supported, please use country codes like SP, IT, GE, etc.");
            }
            if (country == "Selecteer een land")
            {
                throw new ArgumentException("No country was selected.");
            }

            SqlConnection conn = new SqlConnection("Server=tcp:demoserver0331038.database.windows.net,1433;Initial Catalog=ProjectRandomizer;Persist Security Info=False;User ID=demoadmin;Password=Sch00l34&%$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetNames", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter countryParam = cmd.Parameters.Add("@Country", SqlDbType.VarChar, 2);
                SqlParameter amountOfNamesParam = cmd.Parameters.Add("@AmountOfNames", SqlDbType.Int);
                countryParam.Value = country;
                amountOfNamesParam.Value = amountOfNames;
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> names = new();
                while (dr.Read())
                {
                    var name = (string)dr["FirstName"] + " " + (string)dr["LastName"];
                    names.Add(name);
                }

                return names.Count > 0 ? names : new List<string> { "No results where found." };

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region RandomSeason
        /// <summary>The available seasons</summary>
        public enum Seasons
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        private static Seasons _lastSeason;
        /// <summary>Gets a random season.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public static Seasons GetRandomSeason()
        {
            try
            {
                var seasons = Enum.GetValues(typeof(Seasons));
                var randomSeason = (Seasons)seasons.GetValue(rng.Next(seasons.Length));

                return randomSeason;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region RandomTime
        /// <summary>Gets a random time.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.Exception"></exception>
        public static Time GetRandomTime()
        {
            try
            {
                return new Time(rng.Next(1, 24 * 3600));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
