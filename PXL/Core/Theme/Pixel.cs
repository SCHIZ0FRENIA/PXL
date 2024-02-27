using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PXL.Core.Theme
{
    public class Pixel : CheckBox
    {
        public static readonly DependencyProperty PrimaryColorProperty = DependencyProperty.Register("PrimaryColor", typeof(Color), typeof(Pixel));
        public static readonly DependencyProperty AccentColorProperty = DependencyProperty.Register("AccentColor", typeof(Color), typeof(Pixel));
        public static readonly DependencyProperty IsDrawedProperty = DependencyProperty.Register("IsDrawed", typeof(bool), typeof(Pixel));

        public Color PrimaryColor
        {
            get { return (Color)GetValue(PrimaryColorProperty); }
            set { SetValue(PrimaryColorProperty, value); }
        }
        public Color AccentColor
        {
            get { return (Color)GetValue(AccentColorProperty); }
            set { SetValue(AccentColorProperty, value); }
        }
        public bool IsDrawed
        {
            get { return (bool)GetValue(IsDrawedProperty); }
            set { SetValue(IsDrawedProperty, value); }
        }
    }
}
