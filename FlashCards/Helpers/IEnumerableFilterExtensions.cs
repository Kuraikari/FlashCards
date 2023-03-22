using FlashCards.Enums;
using FlashCards.Models.FlashCards;
using System.Runtime.CompilerServices;

namespace FlashCards.Helpers
{
    public static class IEnumerableFilterExtensions
    {
        public static IEnumerable<FlashCardModel> FilterByTopics(this IEnumerable<FlashCardModel> query, Topics topic)
        {
            return query.Where(x => x.Topics == topic);
        }

        public static IEnumerable<FlashCardModel> FilterBySubTopics(this IEnumerable<FlashCardModel> query, string subtopic)
        {
            return query.Where(x => x.SubTopics.Contains(subtopic));
        }
    }
}
