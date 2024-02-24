using System.Windows.Controls;
using PXL.MVVM.ViewModels;

namespace PXL.MVVM.Views
{
    /// <summary>
    /// Interaction logic for NewCBView.xaml
    /// </summary>
    public partial class NewCBView : UserControl
    {
        public NewCBView()
        {
            DataContext = new NewCBViewModel();
            InitializeComponent();
        }
    }
}
