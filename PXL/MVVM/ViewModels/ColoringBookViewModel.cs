using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Media;
using PXL.Core.Services;
using PXL.Core.Types;

namespace PXL.MVVM.ViewModels
{
    public class ColoringBookViewModel
    {
        public CBCollectionService _collectionService;
        public PixelColoringBook ChoosenCB
        {
            get => _collectionService.ChoosenCB;
        }
        public ObservableCollection<System.Windows.Media.Color> DistinctColors
        {
            get => _collectionService.ChoosenCB.SWMCDistinctColors;
        }
        public ObservableCollection<ObservableCollection<System.Windows.Media.Color>> ColorMatrix
        {
            get => _collectionService.ChoosenCB.SWMCMatrix;
        }
        public ColoringBookViewModel(CBCollectionService collectionService)
        {
            _collectionService = collectionService;
        }
    }
}
