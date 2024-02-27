using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PXL.Core.Converters
{
    public class ToSolidBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Drawing.Color drawingColor)
            {
                return new SolidColorBrush(Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B));
            }
            return new SolidColorBrush(Colors.Black); // Default color if conversion fails
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush solidColorBrush)
            {
                return System.Drawing.Color.FromArgb(
                    solidColorBrush.Color.A,
                    solidColorBrush.Color.R,
                    solidColorBrush.Color.G,
                    solidColorBrush.Color.B);
            }
            return System.Drawing.Color.Black; // Default color if conversion fails
        }
    }
}
