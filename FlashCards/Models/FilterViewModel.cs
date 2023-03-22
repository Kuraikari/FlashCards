namespace FlashCards.Models
{
    public class FilterViewModel
    {
        public string[] FilterOptions { get; set; }

        public FilterViewModel(params string[] filters) {
            FilterOptions = filters;
        }
    }
}
