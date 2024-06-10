using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using PXL.Core;
using PXL.Core.Services;
using PXL.Core.Types;

namespace PXL.MVVM.ViewModels
{
    public class ColoringBookViewModel : ObservableObject
    {
        public CBCollectionService _collectionService;
        public RelayCommand ColorChangeCommand { get; set; }
        public RelayCommand IsDrawCommand { get; set; }
        public System.Windows.Media.Color ChosenColor { get; set; }
        public ObservableCollection<System.Windows.Media.Color> DistinctColors
        {
            get => _collectionService.ChoosenCB.SWMCDistinctColors;
        }
        public ObservableCollection<ObservableCollection<PixelLogic>> ColorMatrix
        {
            get => _collectionService.ChoosenCB.MATRIX;
        }

        public void ColorChange(object value)
        {
            ChosenColor = (System.Windows.Media.Color)value;
            foreach ( var row in _collectionService.ChoosenCB.MATRIX)
            {
                foreach( var item in row)
                {
                    item.CanDraw = (item.color == ChosenColor);
                }
            }
            OnPropertyChanged(nameof(_collectionService));
        }

        public void IsDraw(object value)
        {
            
        }

        public bool CanDraw(object value)
        {
            return ((PixelLogic)value).CanDraw;
        }

        public ColoringBookViewModel(CBCollectionService collectionService)
        {
            _collectionService = collectionService;
            ColorChangeCommand = new RelayCommand(ColorChange);
            IsDrawCommand = new RelayCommand(IsDraw, CanDraw);
        }
    }
}
