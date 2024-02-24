using System.Windows.Controls;
using PXL.Core.Services;
using PXL.MVVM.ViewModels;

namespace PXL.MVVM.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView(CBCollectionService collectionService)
        {
            DataContext = new HomeViewModel(collectionService);
            InitializeComponent();
        }
    }
}
