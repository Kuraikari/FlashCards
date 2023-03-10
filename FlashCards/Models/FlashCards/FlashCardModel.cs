using FlashCards.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models.FlashCards
{
    public class FlashCardModel
    {
        public int Id { get; set; }
        public Topics Topics { get; set; }
        [Required]
        public string Front { get; set; }  = string.Empty;
        [Required]
        public string Back { get; set; } = string.Empty;   
    }
}
