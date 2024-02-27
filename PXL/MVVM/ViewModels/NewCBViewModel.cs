using System;
using System.Windows.Forms;
using Microsoft.Win32;
using PXL.Core;
using PXL.Core.Services;
using PXL.Core.Types;
using PXL.MVVM.Models;

namespace PXL.MVVM.ViewModels
{
    public class NewCBViewModel : ObservableObject
    {
        private CBCollectionService _collectionService;
        private NewCBModel _model { get; set; }
        public RelayCommand AddCB { get; }
        public RelayCommand OpenFile { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }

        public void addCB(object value) { _collectionService.AddCB(PixelColoringBook.CreateByFilePath(Name, FilePath)); }
        
        public NewCBViewModel(CBCollectionService collectionService)
        {
            _collectionService = collectionService;
            _model = new NewCBModel();
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
