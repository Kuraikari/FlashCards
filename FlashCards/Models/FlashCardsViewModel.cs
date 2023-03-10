using FlashCards.Models.FlashCards;

namespace FlashCards.Models
{
    public class FlashCardsViewModel<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public FlashCardsViewModel()
        {
            Data = new List<T>();
        }
    }
}
