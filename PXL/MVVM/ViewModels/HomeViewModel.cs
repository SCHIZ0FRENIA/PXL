using System.Collections.ObjectModel;
using PXL.Core.Services;
using PXL.Core.Types;
using PXL.MVVM.Models;

namespace PXL.MVVM.ViewModels
{
    public class HomeViewModel
    {
        private CBCollectionService _collectionService;
        public ObservableCollection<PixelColoringBook> Collection
        {
            get => _collectionService.BookList;
        }
        private HomeModel _model { get; set; }
        public HomeViewModel(CBCollectionService collectionSevice)
        {
            _collectionService = collectionSevice;
            _model = new HomeModel();
        }
    }
}
