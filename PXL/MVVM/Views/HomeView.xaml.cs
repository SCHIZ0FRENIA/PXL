using System.Windows.Controls;
using PXL.Core;
using PXL.Core.Services;
using PXL.MVVM.ViewModels;

namespace PXL.MVVM.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView(CBCollectionService collectionService, RelayCommand toCB)
        {
            DataContext = new HomeViewModel(collectionService, toCB);
            InitializeComponent();
        }
    }
}
