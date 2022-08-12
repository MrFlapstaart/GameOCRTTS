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
                        block = TextHelper.ProcessTextBlock(block);
                        if (block.Lines.Count > 0)
                            ResetBlockBoundaries(block);

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

        private static void ResetBlockBoundaries(TextBlock block)
        {
            foreach (var line in block.Lines)
            {
                line.HPos = line.Words.Min(x => x.HPos);
                line.VPos = line.Words.Min(x => x.VPos);
                line.Width = line.Words.Max(x => x.HPos + x.Width) - line.HPos;
                line.Height = line.Words.Max(x => x.VPos + x.Height) - line.VPos;
            }

            block.HPos = block.Lines.Min(x => x.HPos);
            block.VPos = block.Lines.Min(x => x.VPos);
            block.Width = block.Lines.Max(x => x.HPos + x.Width) - block.HPos + 1;
            block.Height = block.Lines.Max(x => x.VPos + x.Height) - block.VPos + 1;
        }
    }
}
