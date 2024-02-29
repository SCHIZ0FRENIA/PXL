using System;
using System.Windows.Forms;
using PXL.Core;
using PXL.Core.Services;
using PXL.Core.Types;

namespace PXL.MVVM.ViewModels
{
    public class NewCBViewModel : ObservableObject
    {
        private CBCollectionService _collectionService;
        public RelayCommand AddCB { get; }
        public RelayCommand OpenFile { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }

        public void addCB(object value) { _collectionService.AddCB(PixelColoringBook.CreateByFilePath(Name, FilePath)); }
        
        public NewCBViewModel(CBCollectionService collectionService)
        {
            _collectionService = collectionService;
            AddCB = new RelayCommand(addCB);
            OpenFile = new RelayCommand(openFile);
        }

        public void openFile(object value)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Title = "Select an Image File";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
                OnPropertyChanged(nameof(FilePath));
            }
        }
    }
}
