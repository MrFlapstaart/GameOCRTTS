using System.Linq;
using System.Collections.Generic;
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

        internal static TextBlock ProcessTextBlock(TextBlock block)
        {
            Regex rgxspec = new Regex("[^a-zA-Z0-9.,'?!: -]");
            List<TextString> words = new List<TextString>();
            foreach (var line in block.Lines)
            {
                line.Words.RemoveAll(x => string.IsNullOrEmpty(rgxspec.Replace(x.Content.Replace("|", "I"), "").Trim()));
                line.Words.RemoveAll(x => !IsValidWord(x.Content));
                words.AddRange(line.Words);
            }
            double avgheight = words.Average(x => x.Height);
            foreach (var line in block.Lines)
            {
                line.Words.RemoveAll(x => x.Height > avgheight * 1.5 || x.Height < avgheight * 0.5);
            }


            block.Lines.RemoveAll(x => x.WordsInLine == 1 && x.Text.Length <= 2);
            block.Lines.RemoveAll(x => x.WordsInLine == 0);

            return block;
        }

        private static bool IsValidWord(string word)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9']");
            Regex rgxnum = new Regex("[^0-9]");
            Regex rgxvowel = new Regex("[^aeiouy]");

            string strip = rgx.Replace(word, "")?.ToLower()?.Trim();
            if (string.IsNullOrEmpty(strip))
                return false;

            if (strip.Length == 1 && strip != "i" && strip != "a")
                return false;
                       
            string numbers = rgxnum.Replace(word, "");
            bool onlynumbers = numbers.Length == strip.Length && numbers.Length > 0;            
            int vowels = rgxvowel.Replace(strip, "").Length;

            if (strip.Length == 1 && !onlynumbers && strip != "i" && strip != "a")
                return false;


            if (!word.StartsWith("..") && strip.Length <= 5 && strip.Length > 1 && !onlynumbers && !strip.StartsWith("hm") && strip != "you")
            {
                if (vowels == 0 || vowels == strip.Length)
                    return false;
            }

            return true;
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
