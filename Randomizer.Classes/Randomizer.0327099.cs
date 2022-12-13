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

        /// <summary>Gets the image as Byte array</summary>
        /// <param name="includeJokers">if set to <c>true</c> [include jokers].</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static Byte[] getImage(bool includeJokers, bool isUnitTest = false)
        {
            var uwu = Directory.GetCurrentDirectory() + "\\Recources\\Cards\\PNG-cards-1.3\\";
            if (isUnitTest)
            {
                uwu = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\Recources\\Cards\\PNG-cards-1.3\\";
            }

            string[] files = Directory.GetFiles(uwu, "*.png");
            string path = files[rng.Next(files.Length)];
            if (includeJokers == false)
            {
                while (path.Contains("joker"))
                {
                    path = files[rng.Next(files.Length)];
                }
            }
            Byte[] fileBytes = File.ReadAllBytes(path);
            return fileBytes;
        }


        /// <summary>Generates the password.</summary>
        /// <param name="length">The length.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <param name="special">The special.</param>
        /// <param name="num">The number.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentException">Kan geen wachtwoord maken als je geen opties open houd :)</exception>
        public static string generatePassword(int length, bool? lower = true, bool? upper = true, bool? special = true, bool? num = true)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string number = "1234567890";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string specials = "$%#@!*?;:^&";
            string possibles = "";
            string password = "";

            if (lower == true) possibles += lowercase;
            if (upper == true) possibles += uppercase;
            if (num == true) possibles += number;
            if (special == true) possibles += specials;
            if (possibles == "")
            {
                throw new ArgumentException("Kan geen wachtwoord maken als je geen opties open houd :)");
            }

            for (int i = 0; i <= length; i++)
            {
                int index = rng.Next(0, possibles.Length);
                password += possibles[index];
            }
            return password;
        }

        /// <summary>Generates the password.</summary>
        /// <param name="amLower">The am lower.</param>
        /// <param name="amNumber">The am number.</param>
        /// <param name="amUpper">The am upper.</param>
        /// <param name="amSpecial">The am special.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string generatePassword(int? amLower, int? amNumber, int? amUpper, int? amSpecial)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string number = "1234567890";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string specials = "$%#@!*?;:^&";
            string password = "";

            if (amLower != null && amLower != 0)
            {
                for (int i = 0; i < amLower; i++)
                {
                    password += lowercase[rng.Next(0, lowercase.Length)];
                }
            }
            if (amUpper != null && amUpper != 0)
            {
                for (int i = 0; i < amUpper; i++)
                {
                    password += uppercase[rng.Next(0, uppercase.Length)];
                }
            }
            if (amNumber != null && amNumber != 0)
            {
                for (int i = 0; i < amNumber; i++)
                {
                    password += number[rng.Next(0, number.Length)];
                }
            }
            if (amSpecial != null && amSpecial != 0)
            {
                for (int i = 0; i < amSpecial; i++)
                {
                    password += specials[rng.Next(0, specials.Length)];
                }
            }
            if (password == "")
            {
                throw new ArgumentException("kan geen password maken als je alles op 0 zet");
            }
            return Shuffle(password);
        }


        public static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
    }
}
