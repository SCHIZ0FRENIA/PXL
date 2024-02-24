using System.Collections.ObjectModel;
using PXL.Core;
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

        public RelayCommand ToCB { get; }

        public HomeViewModel(CBCollectionService collectionService,RelayCommand toCB)
        {
            _collectionService = collectionService;
            ToCB = toCB;
        }
    }
}
