using System.Windows;
using System.Windows.Navigation;
using PXL.Core;
using PXL.Core.Services;
using PXL.Core.Types;
using PXL.MVVM.Models;
using PXL.MVVM.Views;

namespace PXL.MVVM.ViewModels
{
	/// <summary>
	/// View model for MainView.cs
	/// </summary>
    internal class MainViewModel : ObservableObject
    {
		private CBCollectionService _collectionService;

        private MainModel _model { get; set; }

        public HomeView HomeView { get; set; }
        public NewCBView NewCBView { get; set; }
		public ColoringBookView ColoringBookView { get; set; }

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand NewCBViewCommand { get; set; }
		public RelayCommand ColoringBookCommand { get; set; }

		private object _currenView;
		/// <summary>
		/// This property allows to switch between views.
		/// </summary>
		public object CurrentView
		{
			get
			{
				return _currenView;
			}
			set
			{
				_currenView = value;
				OnPropertyChanged(nameof(CurrentView));
			}
		}

		private void ChangeToHome(object value)
		{
			CurrentView = HomeView;
		}
		private void ChangeToNewCB(object value)
		{
			CurrentView = NewCBView;
		}
		private void ChangeToCB(object value)
		{
            _collectionService.FindCB(value.ToString());
			MessageBox.Show(_collectionService.ChoosenCB.Name);
			CurrentView = new ColoringBookView(_collectionService);
        }
		private bool CanChangeView(object value) { return true; }

		/// <summary>
		/// Initializes new instance of MainViewModel.
		/// </summary>
        public MainViewModel()
        {
			_collectionService = new CBCollectionService();
			_collectionService.AddCB(PixelColoringBook.CreateTestPixelColoringBook("book1", 1, 1));
			_collectionService.AddCB(PixelColoringBook.CreateTestPixelColoringBook("book2", 10, 10));
			_collectionService.AddCB(PixelColoringBook.CreateTestPixelColoringBook("book3", 10, 10));
			_collectionService.AddCB(PixelColoringBook.CreateTestPixelColoringBook("book4", 10, 10));
			_collectionService.FindCB("book1");

			HomeViewCommand = new RelayCommand(ChangeToHome, CanChangeView);
			NewCBViewCommand = new RelayCommand(ChangeToNewCB, CanChangeView);
			ColoringBookCommand = new RelayCommand(ChangeToCB, CanChangeView);

			_model = new MainModel();


            HomeView = new HomeView(_collectionService, ColoringBookCommand);
			NewCBView = new NewCBView(_collectionService);

			CurrentView = HomeView;
        }
    }
}