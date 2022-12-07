﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            } catch (Exception e)
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
                if (numParagraphs <= 0) throw new ArgumentException("aantal paragraden moet hoger zijn dan 0");

                string fileName = useEn ? "lorumipsum.txt" : "lorumipsumnl.txt";
                string[] lines = File.ReadAllLines(@"../Recources/Text/lorumipsum.txt");
                Random rnd = new Random();

                for (int i = 0; i < numParagraphs; i++)
                {
                    int lineNum = rnd.Next(0, lines.Length);
                    string paragraph = lines[lineNum];

                    if (generateAsHtml)
                    {
                        paragraph = "<p>" + paragraph + "</p>";
                    }

                    result += paragraph;
                }
                return result;
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
