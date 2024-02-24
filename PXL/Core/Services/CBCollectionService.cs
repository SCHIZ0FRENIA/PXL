using System.Collections.ObjectModel;
using PXL.Core.Types;

namespace PXL.Core.Services
{
    public class CBCollectionService : ObservableObject
    {
        public ObservableCollection<PixelColoringBook> BookList { get; set; }

        public CBCollectionService()
        {
            
        }
    }
}
