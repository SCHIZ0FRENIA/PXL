using System.Collections.ObjectModel;
using System.ComponentModel;
using PXL.Core.Types;

namespace PXL.Core.Services
{
    public class CBCollectionService : ObservableObject
    {
        public ObservableCollection<PixelColoringBook> BookList { get; set; }

        public CBCollectionService()
        {
            BookList = new ObservableCollection<PixelColoringBook>();
        }

        public void AddCB(PixelColoringBook book)
        {
            BookList.Add(book);
            OnPropertyChanged(nameof(BookList));
        }
    }
}
