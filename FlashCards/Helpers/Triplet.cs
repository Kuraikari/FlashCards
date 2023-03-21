namespace FlashCards.Helpers
{
    public class Triplet<TKey, TValue, TActive> 
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public TActive IsActive { get; set; }

        public Triplet(TKey key, TValue value, TActive isActive)
        {
            Key = key;
            Value = value;
            IsActive = isActive;
        }
    }
}
