using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PXL.Core.Theme
{
    public class Pixel : CheckBox
    {
        public static readonly DependencyProperty PrimaryColorProperty = DependencyProperty.Register("PrimaryColor", typeof(System.Windows.Media.Brush), typeof(Pixel));
        public static readonly DependencyProperty AccentColorProperty = DependencyProperty.Register("AccentColor", typeof(System.Windows.Media.Brush), typeof(Pixel));
        public static readonly DependencyProperty IsDrawedProperty = DependencyProperty.Register("IsDrawed", typeof(bool), typeof(Pixel));

        public System.Windows.Media.Brush PrimaryColor
        {
            get { return (System.Windows.Media.Brush)GetValue(PrimaryColorProperty); }
            set { SetValue(PrimaryColorProperty, value); }
        }
        public System.Windows.Media.Brush AccentColor
        {
            get { return (System.Windows.Media.Brush)GetValue(AccentColorProperty); }
            set { SetValue(AccentColorProperty, value); }
        }
        public bool IsDrawed
        {
            get { return (bool)GetValue(IsDrawedProperty); }
            set { SetValue(IsDrawedProperty, value); }
        }
    }
}
