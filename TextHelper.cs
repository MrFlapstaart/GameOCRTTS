using System;
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

                // 'I' is probably never the last word in a sentence.
                if ((strip == "i" || strip == "a") && word.Length == 1 && wordidx == wordcount)
                    continue;

                if (strip.Length == 1 && !onlynumbers && strip != "i" && strip != "a")
                    continue;

                if (!IsValidWord(word))
                    continue;
                                
                result.Append(FixBrokenWord(word) + " ");
            }

            return result.ToString();
        }

        private static string FixBrokenWord(string word)
        {
            if (word == "Il")
                return "I'll";
            else if (word.ToLower().StartsWith("c'mon"))
                return word.ToLower().Replace("c'mon", "come on");
            else
                return word;
        }

        internal static TextBlock ProcessTextBlock(TextBlock block)
        {
            Regex rgxspec = new Regex("[^a-zA-Z0-9.,'?!: -]");
            List<TextString> words = new List<TextString>();
            foreach (var line in block.Lines)
            {
                line.Words.RemoveAll(x => string.IsNullOrEmpty(rgxspec.Replace(x.Content, "").Trim()));
                line.Words.RemoveAll(x => !IsValidWord(x.Content));
                words.AddRange(line.Words);
            }
            
            //double avgheight = words.Average(x => x.Height);
            //foreach (var line in block.Lines)
            //{
            //    line.Words.RemoveAll(x => x.Height > avgheight * 1.5 || x.Height < avgheight * 0.5);
            //}


            block.Lines.RemoveAll(x => x.WordsInLine == 1 && x.Text.Length <= 2);
            block.Lines.RemoveAll(x => x.WordsInLine == 0);

            return block;
        }

        private static bool IsValidWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            Regex rgx = new Regex("[^a-zA-Z0-9']");
            Regex rgxcap = new Regex("[^A-Z0-9]");
            Regex rgxnum = new Regex("[^0-9]");
            Regex rgxvowel = new Regex("[^aeiouy]");

            string strip = rgx.Replace(word, "")?.ToLower()?.Trim();
            string stripcap = rgxcap.Replace(word, "")?.Trim();

            if (word.StartsWith(".."))
                return true;

            if (string.IsNullOrEmpty(strip))
                return false;
                        
            if (strip.Length == 1 && strip != "i" && strip != "a")
                return false;

            if (strip.Length == 1 && word.Length >= 3)
                return false;
                       
            string numbers = rgxnum.Replace(word, "");
            bool onlynumbers = numbers.Length == strip.Length && numbers.Length > 0;            
            int vowels = rgxvowel.Replace(strip, "").Length;

            if (numbers.Length > 0 && !onlynumbers)
                return false;

            // Word with multiple capitals mixed with non-capitals, porbably not a valid word.
            if (stripcap.Length > 1 && stripcap.Length < strip.Length)
                return false;

            if (strip.Length == 1 && !onlynumbers && !ValidVowelWord(strip))
                return false;

            if (!word.StartsWith("..") && strip.Length <= 5 && strip.Length > 1 && !onlynumbers && !ValidConsonantWord(strip) && !ValidVowelWord(strip))
            {
                if (vowels == 0 || vowels == strip.Length)
                    return false;
            }

            return true;
        }

        private static bool ValidVowelWord(string word)
        {
            string text = word?.ToLower();
            bool result = 
                text == "you" ||
                text == "eye" ||
                text == "i" ||
                text == "yay" ||
                text == "a";

            return result;
        }

        private static bool ValidConsonantWord(string word)
        {
            string text = word?.ToLower() ?? "";
            bool result =
                text.StartsWith("hm") ||
                text.StartsWith("zz");
                
            return result;
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
