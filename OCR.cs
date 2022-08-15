using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Tesseract;
using System.Drawing;

namespace GameOCRTTS
{
    public class OCR
    {        
        private TesseractEngine _Engine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);
        
        public Color Brightest { get; set; } = Color.White;
        public int FadeDistance { get; set; } = 15;
        public int DefaultScaleDPI { get; set; } = 125;
        public int UpscaledDPI { get; set; } = 300;
        public int UpscaleWidth { get; set; } = 1024;

        public OCRResult HandleOCR(Bitmap bitmap, bool forcefullscale)
        {
            Logger.AddLog("Rescaling image.");
            Image resultimage;
            bool fullscale = false;
            if (bitmap.Width <= UpscaleWidth || forcefullscale)
            {
                resultimage = ImageProc.Rescale(bitmap, UpscaledDPI, UpscaledDPI);
                fullscale = true;
            }
            else
                resultimage = ImageProc.Rescale(bitmap, DefaultScaleDPI, DefaultScaleDPI);

            Logger.AddLog("Stripping colors from image.");
            resultimage = ImageProc.StripColorsFromImage(resultimage, Brightest, FadeDistance);

            Logger.AddLog("Handle OCR.");
            TextBlock block = GetTextFromImage(resultimage);
            string resulttext = GetProcessedTextFromBlock(block);

            if (string.IsNullOrEmpty(resulttext) && !fullscale)
            {
                Logger.AddLog("No result, retrying on full scale.");
                resultimage = ImageProc.Rescale(bitmap, 300, 300);
                resultimage = ImageProc.StripColorsFromImage(resultimage, Brightest, FadeDistance);
                block = GetTextFromImage(resultimage);
                resulttext = GetProcessedTextFromBlock(block);
            }

            using (Graphics g = Graphics.FromImage(resultimage))
            {
                var pen = new Pen(Color.Red);
                foreach (var line in block.Lines)
                {
                    g.DrawRectangle(pen, new Rectangle(line.HPos, line.VPos, line.Width, line.Height));
                }
            }

            OCRResult result = new OCRResult();
            result.Block = block;
            result.ResultText = resulttext;
            result.OriginalText = result.OriginalText;
            result.ProcessedImage = resultimage;
            return result;
        }

        private static string GetProcessedTextFromBlock(TextBlock block)
        {            
            string stripped = TextHelper.StripSpecialCharacters(block.Text);
            string result = TextHelper.RemoveGarbageText(stripped);
            return result;
        }

        private TextBlock GetTextFromImage(Image image)
        {
            MemoryStream byteStream = new MemoryStream();
            //image.Save(byteStream, System.Drawing.Imaging.ImageFormat.Tiff);
            //byteStream.Position = 0;
            Rect region = new Rect(0, 0, image.Width, image.Height);
            //TesseractResult tessresult = DoTesseractByTiffStream(byteStream.ToArray(), region);
            TesseractResult tessresult = DoTesseractByImage(image, region);
            TextBlock result = CleanupTextBlocks(tessresult);
            byteStream.Position = 0;
            if (result.HPos > 50 && result.Height > 1)
            {
                //image = ImageProc.CropImage(image, new Rectangle(result.HPos, result.VPos, result.Width, result.Height));
                //image = ImageProc.Rescale(image, 300, 300);
                //image.Save(@"c:\temp\parttest.png");
                region = new Rect(result.HPos - 50, result.VPos - 50, result.Width + 50, result.Height + 50);
                tessresult = DoTesseractByTiffStream(byteStream.ToArray(), region);
                tessresult = DoTesseractByImage(image, new Rect(0, 0, image.Width, image.Height));
                result = CleanupTextBlocks(tessresult);
            }
            result.OriginalText = tessresult.OriginalText;
            return result;
        }

        private TextBlock CleanupTextBlocks(TesseractResult result)
        {
            if ((result?.PrintSpace?.ComposedBlock?.Count ?? 0) == 0)
                throw new Exception("");

            ComposedBlock cblock = result.PrintSpace.ComposedBlock.OrderByDescending(x => x.WordsInComposedBlock).FirstOrDefault() ?? new ComposedBlock();
            TextBlock block = cblock.Blocks.OrderByDescending(x => x.WordsInBlock).FirstOrDefault() ?? new TextBlock();
            TextBlock orgblock = new TextBlock();
            orgblock.Lines.AddRange(block.Lines);

            int linenum = 1;
            foreach (var proccblock in result.PrintSpace.ComposedBlock.OrderBy(x => x.Id))
            {
                foreach (var procblock in proccblock.Blocks.OrderBy(x => x.Id))
                {
                    TextHelper.ProcessTextBlock(procblock);
                    foreach (var procline in procblock.Lines.OrderBy(x => x.Id))
                    {
                        if (procline.Id.Contains("_"))
                            procline.Id = $"line{linenum++:0000}";
                        if (procblock.Id != block.Id)
                        {
                            int eol = procline.HPos + procline.Width;
                            if ((eol >= block.HPos && eol <= block.HPos + block.Width + 50) ||
                                (procblock.VPos >= block.VPos - 10 && procblock.VPos <= block.VPos + 10))
                                block.Lines.Add(procline);
                        }
                    }
                }
            }

            TextHelper.ProcessTextBlock(block);
            if (block.Lines.Count > 0)
                ResetBlockBoundaries(block);

            return block;
        }

        private TesseractResult DoTesseractByTiffStream(byte[] image, Rect region)
        {
            try
            {                
                using (var img = Pix.LoadFromMemory(image))
                {                    
                    using (var page = _Engine.Process(img, region, PageSegMode.Auto))
                    {
                        string text = page.GetText()?.Replace("\n", " ");

                        string xml = page.GetAltoText(1);
                        var serializer = new XmlSerializer(typeof(TesseractResult));
                        TesseractResult result = new TesseractResult();
                        using (TextReader reader = new StringReader(xml))
                        {
                            result = (TesseractResult)serializer.Deserialize(reader);
                        }

                        result.OriginalText = text;
                        return result;                         
                    }
                }                
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error: {ex.Message}\nStack: {ex.StackTrace}");
                return new TesseractResult() { Result = $"Error: {ex.Message}" };
            }            
        }

        private TesseractResult DoTesseractByImage(Image image, Rect region)
        {
            try
            {
                Bitmap bitmap = new Bitmap(image);

                using (var page = _Engine.Process(bitmap, region, PageSegMode.Auto))
                {
                    string text = page.GetText()?.Replace("\n", " ");

                    string xml = page.GetAltoText(1);
                    var serializer = new XmlSerializer(typeof(TesseractResult));
                    TesseractResult result = new TesseractResult();
                    using (TextReader reader = new StringReader(xml))
                    {
                        result = (TesseractResult)serializer.Deserialize(reader);
                    }

                    result.OriginalText = text;
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error: {ex.Message}\nStack: {ex.StackTrace}");
                return new TesseractResult() { Result = $"Error: {ex.Message}" };
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
