using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Tesseract;
using System.Text.RegularExpressions;

namespace GameOCRTTS
{
    internal static class OCR
    {
        private static TesseractEngine _Engine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);

        internal static TextBlock GetTextFromTiffStream(byte[] image)
        {
            try
            {                
                using (var img = Pix.LoadFromMemory(image))
                {
                    using (var page = _Engine.Process(img, PageSegMode.Auto))
                    {
                        string text = page.GetText()?.Replace("\n", " ");

                        string xml = page.GetAltoText(1);
                        var serializer = new XmlSerializer(typeof(OCRResult));
                        OCRResult result = new OCRResult();
                        using (TextReader reader = new StringReader(xml))
                        {
                            result = (OCRResult)serializer.Deserialize(reader);
                        }

                        ComposedBlock cblock = result.PrintSpace.ComposedBlock.OrderByDescending(x => x.WordsInComposedBlock).FirstOrDefault() ?? new ComposedBlock();
                        TextBlock block = cblock.Blocks.OrderByDescending(x => x.WordsInBlock).FirstOrDefault() ?? new TextBlock();

                        Regex rgx = new Regex("[^a-zA-Z0-9.,'?!: -]");
                        foreach (var line in block.Lines)
                        {
                            line.Words.RemoveAll(x => string.IsNullOrEmpty(rgx.Replace(x.Content.Replace("|", "I"), "")));
                        }
                        block.Lines.RemoveAll(x => x.WordsInLine == 0);

                        return block;                            

                    }
                }                
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error: {ex.Message}\nStack: {ex.StackTrace}");
                return new TextBlock() { Text = $"Error: {ex.Message}" };
            }            
        }
    }
}
