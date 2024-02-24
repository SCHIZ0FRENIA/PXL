using System;
using System.Windows;
using System.Windows.Input;
using PXL.MVVM.ViewModels;

namespace PXL.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void OnCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        public MainView()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
