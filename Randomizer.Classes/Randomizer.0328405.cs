using System.Drawing;
using System.Text.Json;
namespace Randomizer.Classes
{
    public static partial class Randomizer
    {
        public static List<int> RandomDice(int amount)
        {
            try
            {
                if (amount <= 0) throw new ArgumentException("Input moet groter zijn dan 0");
                if (amount > 10000) throw new ArgumentException("Input mag niet groter zijn dan 10000");

                List<int> list = new List<int>();
                for (int i = 0; i < amount; i++)
                {
                    list.Add(rng.Next(1, 7));
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string GenerateRandomText(byte numParagraphs, bool useEn, bool generateAsHtml)
        {
            try
            {
                string result = "";

                if (numParagraphs > 10) throw new ArgumentException("aantal paragrafen mag niet hoger zijn dan 10");
                if (numParagraphs <= 0) throw new ArgumentException("aantal paragrafen moet hoger zijn dan 0");

                string[] lines = File.ReadAllLines(@"./Recources/Text/loremipsum.txt");

                if (useEn) lines = File.ReadAllLines(@"./Recources/Text/loremipsumNL.txt");

                for (int i = 0; i < numParagraphs; i++)
                {
                    int lineNum = rng.Next(1, lines.Length);
                    string paragraph = lines[lineNum];

                    if (generateAsHtml)
                    {
                        result += "<p>" + paragraph + "</p>";
                    }
                    else
                    {
                        result += paragraph;
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static string RandomColor(bool knownColor)
        {
            if (knownColor == true)
            {
                Array colorsArray = Enum.GetValues(typeof(KnownColor));
                KnownColor[] allColors = new KnownColor[colorsArray.Length];

                Array.Copy(colorsArray, allColors, colorsArray.Length);
                Color randomColor = Color.FromKnownColor(allColors[rng.Next(0, allColors.Length)]);
                return randomColor.Name;
            }
            Color myColor = Color.FromArgb(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
            string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            return hex;
        }
        public struct Location
        {
            public double Longitude { get; set; }
            public double Latitude { get; set; }
        }

        public static string GetRandomLocation()
        {

            var location = new Location
            {
                Longitude = rng.NextDouble() * 180 - 90,
                Latitude = rng.NextDouble() * 360 - 180
            };

            return JsonSerializer.Serialize(location);
        }
    }
}

