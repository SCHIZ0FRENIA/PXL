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
            if (value is Color color)
            {
                double k = 0.1;

                byte buff = (byte)(color.A * k);
                color.A = buff;
                buff = (byte)(color.R * k);
                color.R = buff;
                buff = (byte)(color.G * k);
                color.G = buff;
                buff = (byte)(color.B * k);
                color.B = buff;

                return new SolidColorBrush(color);
            }
            return null; // Or any default value you wish to return for invalid input
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
