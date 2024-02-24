using PXL.MVVM.Models;

namespace PXL.MVVM.ViewModels
{
    public class HomeViewModel
    {
        private HomeModel _model { get; set; }
        public HomeViewModel()
        {
            _model = new HomeModel();
        }
    }
}
