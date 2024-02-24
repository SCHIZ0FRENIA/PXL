using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PXL.Core.Types;

namespace PXL.Core.Services
{
    public class CBCollectionService : ObservableObject
    {
        public ObservableCollection<PixelColoringBook> BookList { get; set; }

        public PixelColoringBook ChoosenCB { get; set; }

        public CBCollectionService()
        {
            BookList = new ObservableCollection<PixelColoringBook>();
        }

        public void FindCB(string name)
        {
            ChoosenCB = BookList.Where((b) => b.Name == name).FirstOrDefault();
            OnPropertyChanged(nameof(BookList));
            OnPropertyChanged(nameof(ChoosenCB));
        }

        public bool IsNameDistinct(string name)
        {
            return BookList.Any(b => b.Name == name);
        }

        public void AddCB(PixelColoringBook book)
        {
            BookList.Add(book);
            OnPropertyChanged(nameof(BookList));
        }
    }
}
