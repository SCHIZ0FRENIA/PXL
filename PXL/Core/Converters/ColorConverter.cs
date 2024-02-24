﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PXL.Core.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Drawing.Color color)
            {
                return Color.FromArgb(color.A, color.R, color.G, color.B);
            }

            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
