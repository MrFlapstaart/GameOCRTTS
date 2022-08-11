using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
