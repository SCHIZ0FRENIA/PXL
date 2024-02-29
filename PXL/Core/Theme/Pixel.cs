using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PXL.Core.Theme
{
    public class Pixel : CheckBox
    {
        public static readonly DependencyProperty PrimaryColorProperty = DependencyProperty.Register("PrimaryColor", typeof(System.Windows.Media.Brush), typeof(Pixel));
        public static readonly DependencyProperty AccentColorProperty = DependencyProperty.Register("AccentColor", typeof(System.Windows.Media.Brush), typeof(Pixel));
        public static readonly DependencyProperty DarkColorProperty = DependencyProperty.Register("DarkColor", typeof(System.Windows.Media.Brush), typeof(Pixel));
        public static readonly DependencyProperty IsDrawedProperty = DependencyProperty.Register("IsDrawed", typeof(bool), typeof(Pixel));
        public static readonly DependencyProperty CanDrawProperty = DependencyProperty.Register("CanDraw", typeof(bool), typeof(Pixel));

        public System.Windows.Media.Brush PrimaryColor
        {
            get { return (System.Windows.Media.Brush)GetValue(PrimaryColorProperty); }
            set { SetValue(PrimaryColorProperty, value); }
        }
        public System.Windows.Media.Brush DarkColor
        {
            get { return (System.Windows.Media.Brush)GetValue(DarkColorProperty); }
            set { SetValue(DarkColorProperty, value); }
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
        public bool CanDraw
        {
            get { return (bool)GetValue(CanDrawProperty); }
            set { SetValue(CanDrawProperty, value); }
        }
    }
}
