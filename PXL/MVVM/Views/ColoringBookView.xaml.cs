using System.Windows.Controls;
using PXL.Core.Services;
using PXL.MVVM.ViewModels;

namespace PXL.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ColoringBook.xaml
    /// </summary>
    public partial class ColoringBookView : UserControl
    {
        public ColoringBookView(CBCollectionService collectionService)
        {
            DataContext = new ColoringBookViewModel(collectionService);
            InitializeComponent();
        }
    }
}
