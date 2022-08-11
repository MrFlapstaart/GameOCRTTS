using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GameOCRTTS
{
    internal static class ImageProc
    {        
        internal static Bitmap CaptureScreenshot(Rectangle bounds)
        {
            Bitmap bitmap = new Bitmap(bounds.Width - 200, bounds.Height - 80);            
            
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // copy screen with no Windows Border
                g.CopyFromScreen(new Point(bounds.Left, bounds.Top + 50), Point.Empty, bounds.Size);
            }

            return bitmap;            
        }
        internal static Color GetColorFromCurrentPixel()
        {            
            Bitmap bitmap = new Bitmap(10, 10);
             
            using (Graphics g = Graphics.FromImage(bitmap))
            {                
                g.CopyFromScreen(new Point(Cursor.Position.X - 1, Cursor.Position.Y - 1), Point.Empty, bitmap.Size);
            }

            Color result = bitmap.GetPixel(1, 1);
            return result;
        }

        internal static unsafe Bitmap StripColorsFromImage(Image original, Color brightest, int distance)
        {
            int width = original.Width;
            int height = original.Height;
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppPArgb);

            using (Graphics gr = Graphics.FromImage(image))            
                gr.DrawImage(original, new Rectangle(0, 0, width, height));
                                    
            int bytesPerPixel = 4; // R, G, B, A
            int maxPointerLenght = width * height * bytesPerPixel;
            int stride = width * bytesPerPixel;
            byte R, G, B, A;
            
            BitmapData bData = image.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, original.PixelFormat);

            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            for (int i = 0; i < maxPointerLenght; i += 4)
            {
                B = scan0[i + 0];
                G = scan0[i + 1];
                R = scan0[i + 2];
                A = scan0[i + 3];
                                
                // Convert all white pixesls to black.
                if (ColorInRange(R, G, B, brightest, distance))
                {
                    scan0[i + 0] = 0;
                    scan0[i + 1] = 0;
                    scan0[i + 2] = 0;
                }
                // Remove anything else
                else
                {
                    scan0[i + 0] = 255;
                    scan0[i + 1] = 255;
                    scan0[i + 2] = 255;
                }

            }

            image.UnlockBits(bData);
            return image;
        }

        private static bool ColorInRange(byte r, byte g, byte b, Color brightest, int distance)
        {
            byte br = brightest.R;
            byte bg = brightest.G;
            byte bb = brightest.B;

            bool result =
                br - r >= 0 && br - r <= distance &&
                bg - g >= 0 && bg - g <= distance &&
                bb - b >= 0 && bb - b <= distance;

            return result;
        }

        internal static Image Rescale(Image image, int dpiX, int dpiY)
        {
            Bitmap bm = new Bitmap((int)(image.Width * dpiX / image.HorizontalResolution), (int)(image.Height * dpiY / image.VerticalResolution));
            bm.SetResolution(dpiX, dpiY);
            Graphics g = Graphics.FromImage(bm);
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(image, 0, 0);
            g.Dispose();

            return bm;
        }
    }
}
