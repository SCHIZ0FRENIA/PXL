using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PXL.Core.Types
{
    public class PixelColoringBook 
    {
        public string Name { get; }
        public string FilePath { get; set; }
        public ImageSource Source { get; set; }
        public ObservableCollection<ObservableCollection<bool>> IsDrawed { get; set; }
        public ObservableCollection<ObservableCollection<System.Windows.Media.Color>> SWMCMatrix { get; }
        public ObservableCollection<ObservableCollection<System.Drawing.Color>> SDCMatrix { get; }
        public ObservableCollection<System.Windows.Media.Color> SWMCDistinctColors { get; }
        public ObservableCollection<System.Drawing.Color> SDCDistinctColors { get; }

        public PixelColoringBook(string name, ObservableCollection<ObservableCollection<System.Drawing.Color>> sdcMatrix, string filePath = "/img/test.png")
        {
            Name = name;
            FilePath = filePath;
            SDCMatrix = sdcMatrix;

            IsDrawed = new ObservableCollection<ObservableCollection<bool>>();
            foreach (var row in sdcMatrix)
            {
                var newRow = new ObservableCollection<bool>();
                foreach (var item in row)
                {
                    newRow.Add(false);
                }
                IsDrawed.Add(newRow);
            }

            SWMCMatrix = new ObservableCollection<ObservableCollection<System.Windows.Media.Color>>();
            foreach (var row in sdcMatrix)
            {
                var newRow = new ObservableCollection<System.Windows.Media.Color>();
                foreach (var item in row)
                {
                    newRow.Add(PixelColoringBook.ConvertToMediaColor(item));
                }
                SWMCMatrix.Add(newRow);
            }

            SDCDistinctColors = FindDistinctColors(SDCMatrix);
            SWMCDistinctColors = ConvertToMediaColors(SDCDistinctColors);

            Source = ConvertBitmapToImageSource(CreateBitmap(SDCMatrix));
        }

        public static System.Windows.Media.Color ConvertToMediaColor(System.Drawing.Color drawingColor)
        {
            return System.Windows.Media.Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
        }

        public static Bitmap CreateBitmap(ObservableCollection<ObservableCollection<System.Drawing.Color>> colors)
        {
            int width = colors[0].Count;
            int height = colors.Count;

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

        public static ObservableCollection<System.Drawing.Color> FindDistinctColors(ObservableCollection<ObservableCollection<System.Drawing.Color>> colorMatrix)
        {
            var flattenedColors = colorMatrix.SelectMany(row => row);
            HashSet<System.Drawing.Color> distinctColorsHashSet = new HashSet<System.Drawing.Color>();
            foreach (var color in flattenedColors)
            {
                distinctColorsHashSet.Add(color);
            }
            ObservableCollection<System.Drawing.Color> distinctColors = new ObservableCollection<System.Drawing.Color>(distinctColorsHashSet);
            return distinctColors;
        }

        public static ObservableCollection<System.Windows.Media.Color> ConvertToMediaColors(ObservableCollection<System.Drawing.Color> colors)
        {
            return new ObservableCollection<System.Windows.Media.Color>(
                colors.Select(c => System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B))
            );
        }

        public static ObservableCollection<ObservableCollection<System.Drawing.Color>> GenerateTestColorMatrix(int width, int height)
        {
            ObservableCollection<ObservableCollection<System.Drawing.Color>> colorMatrix = new ObservableCollection<ObservableCollection<System.Drawing.Color>>();

            for (int i = 0; i < height; i++)
            {
                ObservableCollection<System.Drawing.Color> row = new ObservableCollection<System.Drawing.Color>();
                for (int j = 0; j < width; j++)
                {
                    int r = (int)(255 * (j / (float)width));
                    int g = (int)(255 * (i / (float)height));
                    int b = 228;

                    row.Add(System.Drawing.Color.FromArgb(r, g, b));
                }
                colorMatrix.Add(row);
            }

            return colorMatrix;
        }

        public static PixelColoringBook CreateTestColorMatrix(string name, int width, int height)
        {
            return new PixelColoringBook(name, GenerateTestColorMatrix(width, height));
        }
    }
}
