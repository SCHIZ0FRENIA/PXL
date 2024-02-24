using System.Windows.Navigation;
using PXL.Core;
using PXL.Core.Services;
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

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand NewCBViewCommand { get; set; }

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
		private bool CanChangeView(object value) { return true; }

		/// <summary>
		/// Initializes new instance of MainViewModel.
		/// </summary>
        public MainViewModel()
        {
			_collectionService = new CBCollectionService();

			_model = new MainModel();

            HomeView = new HomeView(_collectionService);
			NewCBView = new NewCBView(_collectionService);

			CurrentView = HomeView;

			HomeViewCommand = new RelayCommand(ChangeToHome, CanChangeView);
			NewCBViewCommand = new RelayCommand(ChangeToNewCB, CanChangeView);
        }
    }
}