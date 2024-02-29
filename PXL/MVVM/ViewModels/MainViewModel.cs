using PXL.Core;
using PXL.Core.Services;
using PXL.Core.Types;
using PXL.MVVM.Views;

namespace PXL.MVVM.ViewModels
{
    /// <summary>
    /// View model for MainView.cs
    /// </summary>
    internal class MainViewModel : ObservableObject
    {
		private CBCollectionService _collectionService;

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
			CurrentView = new ColoringBookView(_collectionService);
        }
		private bool CanChangeView(object value) { return true; }

		/// <summary>
		/// Initializes new instance of MainViewModel.
		/// </summary>
        public MainViewModel()
        {
			_collectionService = new CBCollectionService();
			

			HomeViewCommand = new RelayCommand(ChangeToHome, CanChangeView);
			NewCBViewCommand = new RelayCommand(ChangeToNewCB, CanChangeView);
			ColoringBookCommand = new RelayCommand(ChangeToCB, CanChangeView);


			_collectionService.AddCB(new PixelColoringBook("Test", "C:\\Users\\User\\Documents\\2.2\\OTHR\\PXL\\PXL\\PXL\\img\\test.png"));
			_collectionService.AddCB(new PixelColoringBook("Test1", "C:\\Users\\User\\Documents\\2.2\\OTHR\\PXL\\PXL\\PXL\\img\\test1.jpg"));



            HomeView = new HomeView(_collectionService, ColoringBookCommand);
			NewCBView = new NewCBView(_collectionService);

			CurrentView = HomeView;
        }

		public void Serialize()
		{

		}

		public void Deserialize()
		{

		}
    }
}