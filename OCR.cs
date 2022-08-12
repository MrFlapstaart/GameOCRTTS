using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Tesseract;

namespace GameOCRTTS
{
    internal static class OCR
    {
        private static TesseractEngine _Engine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);

        internal static OCRResult GetTextFromTiffStream(byte[] image)
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

                        result.Result = text;
                        return result;                            

                    }
                }                
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error: {ex.Message}\nStack: {ex.StackTrace}");
                return new OCRResult() { Result = $"Error: {ex.Message}" };
            }            
        }
    }
}
