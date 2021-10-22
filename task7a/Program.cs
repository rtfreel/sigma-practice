using System;
using System.Collections.Generic;
using System.Text;

namespace task7a
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            Translator t = new Translator();
            string input;
            List<string> unknown;
            while (cont)
            {
                Console.WriteLine("Please, enter sentence to translate:");
                input = Console.ReadLine();//"Hello! My name   is Roman, and yours?";
                unknown = t.Check(input);
                if (unknown.Count > 0) Console.WriteLine("\nProvide translation to replace following words:");
                foreach (string word in unknown)
                {
                    Console.Write(word + " -> ");
                    t.Add(word, Console.ReadLine());
                }
                Console.WriteLine("\nResult:\n" + t.Translate(input));

                Console.Write("\nDo you want to continue with current dictionary? (y/n) ");
                cont = Console.ReadLine().ToLower().Equals("y");
                Console.WriteLine("\nCurrent dictionary:\n" + DictToStr(t.GetDict()));
            }
        }
        static string DictToStr(Dictionary<string, string> dict)
        {
            StringBuilder sb = new StringBuilder();
            foreach(KeyValuePair<string, string> kv in dict)
            {
                sb.Append($"\"{kv.Key}\" -> \"{kv.Value}\"\n");
            }
            return sb.ToString();
        }
    }
}
