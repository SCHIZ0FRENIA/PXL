using System.Windows.Controls;
using PXL.Core.Services;
using PXL.MVVM.ViewModels;

namespace PXL.MVVM.Views
{
    /// <summary>
    /// Interaction logic for NewCBView.xaml
    /// </summary>
    public partial class NewCBView : UserControl
    {
        public NewCBView(CBCollectionService cBCollectionService)
        {
            DataContext = new NewCBViewModel(cBCollectionService);
            InitializeComponent();
        }
    }
}
