using System;
using System.Diagnostics;
using Tesseract;

namespace GameOCRTTS
{
    internal static class OCR
    {
        private static TesseractEngine _Engine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);

        internal static string GetTextFromTiffStream(byte[] image)
        {
            try
            {                
                using (var img = Pix.LoadFromMemory(image))
                {
                    using (var page = _Engine.Process(img, PageSegMode.Auto))
                    {
                        string text = page.GetText()?.Replace("\n", " ");

                        string xml = page.GetAltoText(1);
                        return text;                            
                    }
                }                
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }

            return "Error";
        }
    }
}
