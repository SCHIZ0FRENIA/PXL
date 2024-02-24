using PXL.Core.Services;
using PXL.MVVM.Models;

namespace PXL.MVVM.ViewModels
{
    public class NewCBViewModel
    {
        private CBCollectionService _collectionService;
        private NewCBModel _model { get; set; }
        public NewCBViewModel(CBCollectionService collectionService)
        {
            _collectionService = collectionService;
            _model = new NewCBModel();
        }
    }
}
