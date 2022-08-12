using System.Text;
using System.Text.RegularExpressions;

namespace GameOCRTTS
{
    internal static class TextHelper
    {
        internal static string RemoveGarbageText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            Regex rgx = new Regex("[^a-zA-Z0-9']");
            Regex rgxnum = new Regex("[^0-9]");
            var result = new StringBuilder();

            string parsedtext = text
                    .Replace("..", " ..")
                    .Replace("?", "? ")
                    .Replace("!", "! ")
                    .Replace(".", ". ")
                    .Replace(". .", "..")
                    .Replace(". .", "..")
                    .Replace("' Il", "'ll")
                    .Replace("'Il", "'ll")
                    .Replace("  ", " ");

            string[] words = parsedtext.Split(' ');
            int wordcount = words.Length;
            int wordidx = 0;
            foreach (string word in words)
            {
                wordidx++;
                if (string.IsNullOrEmpty(word))
                    continue;

                string strip = rgx.Replace(word, "")?.ToLower();
                string numbers = rgxnum.Replace(word, "");
                bool onlynumbers = numbers.Length == strip.Length && numbers.Length > 0;

                // Unlikely text block starts or ends with a number
                if (onlynumbers && (wordidx == 1 || wordidx == wordcount ))
                    continue;
                                
                if (strip.Length == 1 && !onlynumbers && strip != "i" && strip != "a")
                    continue;

                if (!word.StartsWith("..") && strip.Length <= 5 && !onlynumbers && strip.Split(new char[] { 'e', 'a', 'u', 'o', 'i', 'y' }).Length == 1 && !strip.StartsWith("hm"))
                    continue;

                result.Append(word + " ");
            }

            return result.ToString();
        }

        internal static string StripSpecialCharacters(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            Regex rgx = new Regex("[^a-zA-Z0-9.,'?!: -]");
            string result = rgx.Replace(text.Replace("|", "I"), "");
            return result;
        }
    }
}
