using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace task7a
{
    class Translator
    {
        private static readonly char[] delimiters = { ' ', ',', '!', '?', '\'', '"', '.', ':', '\t', '\n'};
        private Dictionary<string, string> dict;

        public Translator()
        {
            dict = new Dictionary<string, string>();
        }

        public Translator(Dictionary<string, string> dict)
        {
            this.dict = dict;
        }

        public void Add(string key, string value)
        {
            dict.Add(key.Trim().ToLower(), value.Trim().ToLower());
        }

        public Dictionary<string, string> GetDict() { return dict; }

        //returs unknown words
        public List<string> Check(string input)
        {
            List<string> result = new List<string>();
            string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            bool known;
            for (int i = 0; i < words.Length; i++) {
                words[i] = words[i].ToLower();
                known = false;
                foreach (KeyValuePair<string, string> kv in dict)
                {
                    if (words[i].Equals(kv.Key))
                    {
                        known = true;
                        break;
                    }
                }
                if (!known) result.Add(words[i]);
            }
            return result;
        }

        public string Translate(string input)
        {
            string result = input;
            foreach (KeyValuePair<string, string> kv in dict)
            {
                result = Regex.Replace(result, kv.Key, match =>
                {
                    bool isUpper = char.IsUpper(match.Value[0]);
                    char[] word = kv.Value.ToCharArray();
                    word[0] = isUpper
                        ? char.ToUpper(word[0])
                        : char.ToLower(word[0]);
                    return new string(word);
                }, RegexOptions.IgnoreCase);
            }
            return result;
        }
    }
}
