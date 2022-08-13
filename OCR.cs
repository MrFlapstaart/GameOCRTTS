using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Tesseract;
using System.Drawing;

namespace GameOCRTTS
{
    internal static class OCR
    {
        private static TesseractEngine _Engine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);

        internal static OCRResult HandleOCR(Bitmap bitmap, Color brightest, int fadedistance)
        {
            Logger.AddLog("Rescaling image.");
            Image resultimage;
            bool fullscale = false;
            if (bitmap.Width <= 1024)
            {
                resultimage = ImageProc.Rescale(bitmap, 300, 300);
                fullscale = true;
            }
            else
                resultimage = ImageProc.Rescale(bitmap, 125, 125);

            Logger.AddLog("Stripping colors from image.");
            resultimage = ImageProc.StripColorsFromImage(resultimage, brightest, fadedistance);

            Logger.AddLog("Handle OCR.");
            TextBlock block = GetTextFromImage(resultimage);
            string resulttext = GetProcessedTextFromBlock(block);

            if (string.IsNullOrEmpty(resulttext) && !fullscale)
            {
                Logger.AddLog("No result, retrying on full scale.");
                resultimage = ImageProc.Rescale(bitmap, 300, 300);
                resultimage = ImageProc.StripColorsFromImage(resultimage, brightest, fadedistance);
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
            result.ProcessedImage = resultimage;
            return result;
        }

        internal static string GetProcessedTextFromBlock(TextBlock block)
        {            
            string stripped = TextHelper.StripSpecialCharacters(block.Text);
            string result = TextHelper.RemoveGarbageText(stripped);
            return result;
        }


        internal static TextBlock GetTextFromImage(Image image)
        {
            MemoryStream byteStream = new MemoryStream();
            image.Save(byteStream, System.Drawing.Imaging.ImageFormat.Tiff);
            byteStream.Position = 0;
            TextBlock result = GetTextFromTiffStream(byteStream.ToArray());
            return result;
        }

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
                        var serializer = new XmlSerializer(typeof(TesseractResult));
                        TesseractResult result = new TesseractResult();
                        using (TextReader reader = new StringReader(xml))
                        {
                            result = (TesseractResult)serializer.Deserialize(reader);
                        }

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
