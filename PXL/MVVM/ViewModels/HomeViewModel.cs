using PXL.Core.Services;
using PXL.MVVM.Models;

namespace PXL.MVVM.ViewModels
{
    public class HomeViewModel
    {
        private CBCollectionService _collectionService;
        private HomeModel _model { get; set; }
        public HomeViewModel(CBCollectionService collectionSevice)
        {
            _collectionService = collectionSevice;
            _model = new HomeModel();
        }
    }
}
