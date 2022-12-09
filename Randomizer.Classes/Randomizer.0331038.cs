using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    allFirstNames.AddRange(File.ReadAllLines("./Recources/Text/jongensvoornamen.txt").ToList());
                }

                if (girl)
                {
                    allFirstNames.AddRange(File.ReadAllLines("./Recources/Text/meisjesvoornamen.txt").ToList());
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
    }
}
