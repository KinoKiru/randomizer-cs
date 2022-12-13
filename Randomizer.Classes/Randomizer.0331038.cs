using Microsoft.Data.SqlClient;
using System.Data;

namespace Randomizer.Classes
{
    public static partial class Randomizer
    {
        /// <summary>Gets a random first names of boys/girls depending on your prefrences.</summary>
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

            SqlConnection conn = new SqlConnection("Server=.;Database=RandomizerDB;Trusted_Connection=True;");
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
                    names.Add((string)dr["LastName"]);
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
    }
}
