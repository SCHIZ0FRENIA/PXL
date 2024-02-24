using PXL.Core;
using PXL.Core.Services;
using PXL.Core.Types;
using PXL.MVVM.Models;

namespace PXL.MVVM.ViewModels
{
    public class NewCBViewModel
    {
        private CBCollectionService _collectionService;
        private NewCBModel _model { get; set; }
        public RelayCommand ADDTEST { get; }

        public void addTest(object value) { _collectionService.AddCB(PixelColoringBook.CreateTestPixelColoringBook("TEST", 30, 30)); }
        public NewCBViewModel(CBCollectionService collectionService)
        {
            _collectionService = collectionService;
            _model = new NewCBModel();
            ADDTEST = new RelayCommand(addTest);
        }

    }
}
