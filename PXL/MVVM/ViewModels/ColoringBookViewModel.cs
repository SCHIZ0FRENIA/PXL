using System.Drawing;
using System.Windows.Navigation;
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
        public Color[] DistinctColors
        {
            get => _collectionService.ChoosenCB.DistinctColors;
        }
        public ColoringBookViewModel(CBCollectionService collectionService)
        {
            _collectionService = collectionService;
        }
    }
}
