using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PXL.Core.Types
{
    public class PixelColoringBook
    {
        public string Name { get; }
        public System.Drawing.Color[][] ColorMatrix { get; }
        public System.Drawing.Color[] DistinctColors { get; }
        public string FilePath { get; }
        public ImageSource Source { get; }

        public PixelColoringBook(string name, System.Drawing.Color[][] colorMatrix, string filePath = "/img/test.png")
        {
            Name = name;
            ColorMatrix = colorMatrix;
            DistinctColors = FindDistinctColors();
            FilePath = filePath;
            Source = ConvertBitmapToImageSource(CreateBitmap(colorMatrix));
        }

        public static Bitmap CreateBitmap(System.Drawing.Color[][] colors)
        {
            int width = colors[0].Length;
            int height = colors.Length;

            Bitmap bitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bitmap.SetPixel(x, y, colors[y][x]);
                }
            }

            return bitmap;
        }

        public static ImageSource ConvertBitmapToImageSource(Bitmap bitmap)
        {
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(memoryStream.ToArray());
            bitmapImage.EndInit();

            return bitmapImage;
        }

        private System.Drawing.Color[] FindDistinctColors()
        {
            System.Drawing.Color[] flattenedColors = ColorMatrix.SelectMany(row => row).ToArray();
            System.Drawing.Color[] distinctColors = flattenedColors.Distinct().ToArray();

            return distinctColors;
        }

        private static System.Drawing.Color[][] GenerateTestColorMatrix(int width, int height)
        {
            System.Drawing.Color[][] colorMatrix = new System.Drawing.Color[height][];

            for (int i = 0; i < height; i++)
            {
                colorMatrix[i] = new System.Drawing.Color[width];
                for (int j = 0; j < width; j++)
                {
                    int r = (int)(255 * (j / (float)width));
                    int g = (int)(255 * (i / (float)height));
                    int b = 228;

                    colorMatrix[i][j] = System.Drawing.Color.FromArgb(r, g, b);
                }
            }

            return colorMatrix;
        }

        public static PixelColoringBook CreateTestPixelColoringBook(string name, int width, int height)
        {
            System.Drawing.Color[][] testColorMatrix = GenerateTestColorMatrix(width, height);
            return new PixelColoringBook(name, testColorMatrix);
        }
    }
}
