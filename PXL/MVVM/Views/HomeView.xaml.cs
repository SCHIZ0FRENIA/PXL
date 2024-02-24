﻿using System.Windows.Controls;
using PXL.MVVM.ViewModels;

namespace PXL.MVVM.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            DataContext = new HomeViewModel();
            InitializeComponent();
        }
    }
}
